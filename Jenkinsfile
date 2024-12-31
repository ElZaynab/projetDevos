pipeline {
    agent {
        docker { image 'mcr.microsoft.com/dotnet/sdk:6.0' }
    }
    stages {
        stage('Cloner le projet') {
            steps {
                git 'https://github.com/ElZaynab/projetDevos.git'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }
        stage('Docker Build') {
            steps {
                sh 'docker build -t zaynab790/projetdevos .'
            }
        }
        stage('Docker Push') {
            steps {
                sh 'docker push zaynab790/projetdevos:latest'
            }
        }
    }
}
