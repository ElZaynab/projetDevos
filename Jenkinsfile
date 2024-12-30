pipeline {
    agent any
    stages {
        stage('Cloner le dépôt') {
            steps {
                git credentialsId: 'git-credentials-id', url: 'https://github.com/ElZaynab/ton-projet.git', branch: 'main'
            }
        }
        stage('Tests') {
            steps {
                sh 'dotnet test'
            }
        }
        stage('Créer une image Docker') {
            steps {
                sh 'docker build -t elzaynab/ton-projet:latest .'
            }
        }
        stage('Pousser l’image Docker') {
            steps {
                withDockerRegistry([credentialsId: 'dockerhub-credentials', url: '']) {
                    sh 'docker push elzaynab/ton-projet:latest'
                }
            }
        }
        stage('Déploiement') {
            steps {
                sh 'docker run -d -p 80:80 elzaynab/ton-projet:latest'
            }
        }
    }
}
