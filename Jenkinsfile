pipeline {
  agent any
  stages {
    stage('Set up config') {
      steps {
        sh '''cd TgBot
rm Config.cs
ls'''
        sh '''cd TgBot
echo "namespace TgBot {public struct Config { public static string TelegramToken = \\"1724781462:AAF4ufN5h4Yo0dSmgyY6qn893gF4SU7zVIE\\"; public static string ConnectionTobString = \\"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234\\"; }}" > Config.cs'''
      }
    }

    stage('Build') {
      steps {
        sh '''cd TgBot
dotnet build'''
      }
    }

    stage('Run') {
      steps {
        sh '''cd TgBot
cd bin/Debug/net5.0/
dotnet TgBot.dll'''
      }
    }

  }
}