
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string]$Message,

    [Parameter(Position = 1)]
    [string[]]$Files = @(".")
)

$ErrorActionPreference = "Stop"

# Find the repository root from this script's location
$RepoRoot = git -C $PSScriptRoot rev-parse --show-toplevel

if ($LASTEXITCODE -ne 0 -or -not $RepoRoot) {
    throw "Could not locate the Git repository."
}

Set-Location $RepoRoot

Write-Host "`n=== Git Status ===" -ForegroundColor Cyan
git status
if ($LASTEXITCODE -ne 0) { throw "Git status failed." }

Write-Host "`n=== Current Changes ===" -ForegroundColor Cyan
git diff
if ($LASTEXITCODE -ne 0) { throw "Git diff failed." }

Write-Host "`n=== Staging Files ===" -ForegroundColor Cyan
git add -- $Files
if ($LASTEXITCODE -ne 0) { throw "Git add failed." }

Write-Host "`n=== Staged Changes ===" -ForegroundColor Cyan
git diff --cached
if ($LASTEXITCODE -ne 0) { throw "Staged diff failed." }

# Avoid an empty commit
git diff --cached --quiet
if ($LASTEXITCODE -eq 0) {
    Write-Host "No staged changes to commit." -ForegroundColor Yellow
    exit 0
}

$ConfirmCommit = Read-Host "`nCommit and push these changes? (y/n)"

if ($ConfirmCommit -ne "y") {
    Write-Host "Cancelled. Staged changes are preserved." `
        -ForegroundColor Yellow
    exit 0
}

Write-Host "`n=== Commit ===" -ForegroundColor Cyan
git commit -m $Message
if ($LASTEXITCODE -ne 0) { throw "Commit failed." }

Write-Host "`n=== Push ===" -ForegroundColor Cyan
git push
if ($LASTEXITCODE -ne 0) {
    throw "Push failed. Your commit remains local."
}

Write-Host "`nCommit and push successful!" -ForegroundColor Green
