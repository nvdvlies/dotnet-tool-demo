# dotnet-tool-demo

.NET Core Global Tool demo

## Installation

```
dotnet pack
```

```
dotnet tool install --global --add-source ./nupkg dotnettool.demo
```

## Usage

```
dotnet demo --help
```

```
dotnet demo -o option1 argument1
```

## Uninstall

```
dotnet tool uninstall --global dotnettool.demo
```