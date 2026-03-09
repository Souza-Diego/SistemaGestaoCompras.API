using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var dir = new DirectoryInfo(AppContext.BaseDirectory);

while (dir != null && !dir.GetFiles("*.sln").Any())
{
    dir = dir.Parent;
}

if (dir == null)
{
    Console.WriteLine("Solution root não encontrado.");
    return;
}

var solutionRoot = dir.FullName;

var docsPath = Path.Combine(solutionRoot, "docs");

Directory.CreateDirectory(docsPath);

var mapaPath = Path.Combine(docsPath, "Mapa_Estrutural_Projeto.md");
var snapshotPath = Path.Combine(docsPath, "Architecture_Snapshot.md");

var csFiles = Directory.GetFiles(solutionRoot, "*.cs", SearchOption.AllDirectories)
.Where(f => !f.Contains("bin") && !f.Contains("obj") && !f.Contains("DocGenerator"));

var domainEntities = new List<ClassDeclarationSyntax>();
var valueObjects = new List<ClassDeclarationSyntax>();
var domainServices = new List<ClassDeclarationSyntax>();
var dtos = new List<ClassDeclarationSyntax>();
var useCases = new List<ClassDeclarationSyntax>();
var repositories = new List<ClassDeclarationSyntax>();
var controllers = new List<ClassDeclarationSyntax>();
var interfaces = new List<InterfaceDeclarationSyntax>();
var enums = new List<EnumDeclarationSyntax>();

foreach (var file in csFiles)
{
    var code = File.ReadAllText(file);
    var tree = CSharpSyntaxTree.ParseText(code);
    var root = tree.GetRoot();

    var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
    var ifaces = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
    var ens = root.DescendantNodes().OfType<EnumDeclarationSyntax>();

    enums.AddRange(ens);
    interfaces.AddRange(ifaces);

    foreach (var cls in classes)
    {
        var path = file.ToLower();

        if (path.Contains("domain") && path.Contains("entities"))
            domainEntities.Add(cls);

        else if (path.Contains("domain") && path.Contains("valueobjects"))
            valueObjects.Add(cls);

        else if (path.Contains("domain") && path.Contains("services"))
            domainServices.Add(cls);

        else if (cls.Identifier.Text.EndsWith("Dto", StringComparison.OrdinalIgnoreCase))
            dtos.Add(cls);

        else if (cls.Identifier.Text.EndsWith("UseCase", StringComparison.OrdinalIgnoreCase))
            useCases.Add(cls);

        else if (path.Contains("repositories"))
            repositories.Add(cls);

        else if (cls.Identifier.Text.EndsWith("Controller"))
            controllers.Add(cls);
    }
}

string ClassDetails(ClassDeclarationSyntax cls)
{
    var sb = new StringBuilder();

    sb.AppendLine($"## Classe: {cls.Identifier}");
    sb.AppendLine();

    var props = cls.Members.OfType<PropertyDeclarationSyntax>();
    if (props.Any())
    {
        sb.AppendLine("### Propriedades");
        foreach (var p in props)
            sb.AppendLine($"- {p.Type} {p.Identifier}");
        sb.AppendLine();
    }

    var ctors = cls.Members.OfType<ConstructorDeclarationSyntax>();
    if (ctors.Any())
    {
        sb.AppendLine("### Construtores");
        foreach (var c in ctors)
        {
            var parameters = string.Join(", ", c.ParameterList.Parameters.Select(p => $"{p.Type} {p.Identifier}"));
            sb.AppendLine($"- {cls.Identifier}({parameters})");
        }
        sb.AppendLine();
    }

    var methods = cls.Members.OfType<MethodDeclarationSyntax>();
    if (methods.Any())
    {
        sb.AppendLine("### Métodos");
        foreach (var m in methods)
            sb.AppendLine($"- {m.ReturnType} {m.Identifier}()");
        sb.AppendLine();
    }

    sb.AppendLine("---");

    return sb.ToString();
}

var mapa = new StringBuilder();

mapa.AppendLine("# Mapa Estrutural do Projeto");
mapa.AppendLine();

void Section(StringBuilder sb, string title, IEnumerable<ClassDeclarationSyntax> classes)
{
    if (!classes.Any()) return;

    sb.AppendLine($"# {title}");
    sb.AppendLine();

    foreach (var c in classes)
        sb.Append(ClassDetails(c));
}

Section(mapa, "Domain - Entities", domainEntities);
Section(mapa, "Domain - ValueObjects", valueObjects);
Section(mapa, "Domain - Services", domainServices);
Section(mapa, "Application - DTOs", dtos);
Section(mapa, "Application - UseCases", useCases);
Section(mapa, "Infrastructure - Repositories", repositories);
Section(mapa, "API - Controllers", controllers);

if (interfaces.Any())
{
    mapa.AppendLine("# Interfaces");
    mapa.AppendLine();

    foreach (var i in interfaces)
        mapa.AppendLine($"- {i.Identifier}");

    mapa.AppendLine();
}

if (enums.Any())
{
    mapa.AppendLine("# Enums");
    mapa.AppendLine();

    foreach (var e in enums)
    {
        mapa.AppendLine($"## {e.Identifier}");
        foreach (var m in e.Members)
            mapa.AppendLine($"- {m.Identifier}");
        mapa.AppendLine();
    }
}

File.WriteAllText(mapaPath, mapa.ToString());

var repoInterfaces = interfaces
    .Where(i => i.Identifier.Text.Contains("Repositorio") ||
                i.Identifier.Text.Contains("Repository"))
    .ToList();

var snapshot = new StringBuilder();

snapshot.AppendLine("# Architecture Snapshot");
snapshot.AppendLine();

snapshot.AppendLine("## Estrutura do Sistema");
snapshot.AppendLine();

snapshot.AppendLine("### Domain");
snapshot.AppendLine($"- Entities: {domainEntities.Count}");
snapshot.AppendLine($"- ValueObjects: {valueObjects.Count}");
snapshot.AppendLine($"- Services: {domainServices.Count}");
snapshot.AppendLine($"- Enums: {enums.Count}");
snapshot.AppendLine($"- Repository Interfaces: {repoInterfaces.Count}");
snapshot.AppendLine();

snapshot.AppendLine("#### Entities");
foreach (var e in domainEntities)
    snapshot.AppendLine($"- {e.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("#### ValueObjects");
foreach (var v in valueObjects)
    snapshot.AppendLine($"- {v.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("#### Domain Services");
foreach (var s in domainServices)
    snapshot.AppendLine($"- {s.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("#### Enums");
foreach (var e in enums)
    snapshot.AppendLine($"- {e.Identifier}");
snapshot.AppendLine();

if (repoInterfaces.Any())
{
    snapshot.AppendLine("#### Repository Interfaces");
    snapshot.AppendLine();

    foreach (var r in repoInterfaces)
        snapshot.AppendLine($"- {r.Identifier}");

    snapshot.AppendLine();
}

snapshot.AppendLine("### Application");
snapshot.AppendLine($"- DTOs: {dtos.Count}");
snapshot.AppendLine($"- UseCases: {useCases.Count}");
snapshot.AppendLine();

snapshot.AppendLine("#### DTOs");
foreach (var d in dtos)
    snapshot.AppendLine($"- {d.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("#### UseCases");
foreach (var u in useCases)
    snapshot.AppendLine($"- {u.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("### Infrastructure");
snapshot.AppendLine($"- Repositories: {repositories.Count}");
snapshot.AppendLine();

snapshot.AppendLine("#### Repositories");
foreach (var r in repositories)
    snapshot.AppendLine($"- {r.Identifier}");
snapshot.AppendLine();

snapshot.AppendLine("### API");
snapshot.AppendLine($"- Controllers: {controllers.Count}");
snapshot.AppendLine();

snapshot.AppendLine("#### Controllers");
foreach (var c in controllers)
    snapshot.AppendLine($"- {c.Identifier}");
snapshot.AppendLine();



File.WriteAllText(snapshotPath, snapshot.ToString());

Console.WriteLine("Documentação gerada:");
Console.WriteLine(mapaPath);
Console.WriteLine(snapshotPath);

Console.ReadKey();