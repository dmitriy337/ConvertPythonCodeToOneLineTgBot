pipeline {
  agent any
  stages {
    stage('Set up config') {
      steps {
        sh 'cd TgBot'
        sh 'rm Config.cs'
        sh 'echo "namespace TgBot {public struct Config { public static string TelegramToken = \\"1724781462:AAHi7SmnfQmPQKAtxWKjghwDFbSlJ53qeeQ\\"; public static string ConnectionTobString = \\"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234\\"; }}" > Config.cs'
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet build'
      }
    }

    stage('Run') {
      steps {
        sh 'cd bin/Debug/net5.0/'
        sh 'dotnet TgBot.dll'
      }
    }

  }
}