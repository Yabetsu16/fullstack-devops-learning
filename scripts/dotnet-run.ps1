
param(
    [Parameter()]
    [string]$Url = "http://localhost:5080"
)

$ErrorActionPreference = "Stop"

# Find the repository root
$RepoRoot = git -C $PSScriptRoot rev-parse --show-toplevel

if ($LASTEXITCODE -ne 0 -or -not $RepoRoot) {
    throw "Could not locate the Git repository."
}

# Locate the API project
$ProjectPath = Join-Path $RepoRoot "Portfolio.Api\Portfolio.Api.csproj"

if (-not (Test-Path $ProjectPath)) {
    throw "API project not found: $ProjectPath"
}

# Run the API
Write-Host "Starting Portfolio API..." -ForegroundColor Cyan
Write-Host "URL: $Url" -ForegroundColor Green
Write-Host "Press Ctrl+C to stop the API." -ForegroundColor Yellow

dotnet run --project $ProjectPath --urls $Url
