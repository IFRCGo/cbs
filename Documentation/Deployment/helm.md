---
title: Deploying to Azure Dev using Helm
description: Learn how to deploy the latest build to Azure Dev
keywords: Helm Deployment
author: jakhog
---
# Helm Deployment

First of all, you need access to Norwegian Red Cross Azure organization,
@karolikl should be the one to help you with that. Once that is in place, you
need to install some tools to get started. So, go get yourself:
 - Install [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
 - Download [kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl/#before-you-begin), extract it somewhere and add that somewhere to your $PATH
 - Download [helm](https://github.com/kubernetes/helm/releases), extract it somewhere and add that somewhere to your $PATH

 ### Connecting your local kubectl to the Azure
 After installing the tools above, you need to run the following commands on your computer (only once)
 ```
 az login
 az aks get-credentials --resource-group CBS2.0-Dev-RG --name CBS-DEV-AKS
 ```

 ### Deploying the latest build images to the Azure Kubernetes cluster
 From your local cbs-repo clone, run:
 ```
 helm upgrade vested-quokka Deploy
 ```

 You can check the status of the deploytment by running:
 ```
 helm status vested-quokka
 ```

 If you make a mistake, you can roll back to the previous release by running:
 ```
 helm rollback vested-quokka 0
 ```
