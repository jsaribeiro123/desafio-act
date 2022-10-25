dotnet new sln
    
dotnet new web   -o .\Api\Producer\Lancamento   -n  Api.Producer.Lancamento
dotnet new xunit -o .\Tests\Producer\Lancamento -n  Api.Producer.Lancamento.Test

dotnet add          .\Tests\Producer\Lancamento\Api.Producer.Lancamento.Test.csproj reference .\Api\Producer\Lancamento\Api.Producer.Lancamento.csproj

dotnet sln add      .\Tests\Producer\Lancamento\Api.Producer.Lancamento.Test.csproj
dotnet sln add      .\Api\Producer\Lancamento\Api.Producer.Lancamento.csproj

dotnet new web -o   .\Api\Producer\Report  -n Api.Producer.Report
dotnet new xunit -o .\Tests\Producer\Report -n Api.Producer.Report.Test

dotnet add          .\Tests\Producer\Report\Api.Producer.Report.Test.csproj reference .\Api\Producer\Report\Api.Producer.Report.csproj

dotnet new web -o   .\Api\Consumer\Lancamento -n  Api.Consumer.Lancamento
dotnet new xunit -o .\Tests\Consumer\Lancamento -n  Api.Consumer.Lancamento.Test

dotnet add          .\Tests\Consumer\Lancamento\Api.Consumer.Lancamento.Test.csproj reference .\Api\Consumer\Lancamento\Api.Consumer.Lancamento.csproj

dotnet sln add      .\Tests\Consumer\Lancamento\Api.Consumer.Lancamento.Test.csproj
dotnet sln add      .\Api\Consumer\Lancamento\Api.Consumer.Lancamento.csproj

dotnet new web -o   .\Api\Consumer\Report  -n Api.Consumer.Report
dotnet new xunit -o .\Tests\Consumer\Report -n Api.Consumer.Report.Test

dotnet add          .\Tests\Consumer\Report\Api.Consumer.Report.Test.csproj reference .\Api\Consumer\Report\Api.Consumer.Report.csproj

dotnet sln add      .\Tests\Consumer\Report\Api.Consumer.Report.Test.csproj
dotnet sln add      .\Api\Consumer\Report\Api.Consumer.Report.csproj  


$temp = dotnet --list-sdks | select -Last 1
$framework = "net6.0"
$mynetver = $temp.split()
$mynetver[0]
$appname = "myconsole"

dotnet new console -lang c# -n $appname  -f $framework
dotnet new sln -o $appname
dotnet sln $appname add $appname