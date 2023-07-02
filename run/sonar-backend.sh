#!/bin/bash
DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" &>/dev/null && pwd)"
dir_prefix=${DIR%/run}
APP_DIR="${dir_prefix}/code/"
(
    cd "$APP_DIR" &&
        dotnet dotnet sonarscanner begin /k:"uluarsite" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_a8e6bba87968907e40373e6b974357ab8b175054"
    dotnet build AllProjectFiles.sln
    dotnet test --collect:"XPlat Code Coverage;Format=cobertura,opencover"
    dotnet dotnet sonarscanner end /d:sonar.token="sqp_a8e6bba87968907e40373e6b974357ab8b175054"
)
