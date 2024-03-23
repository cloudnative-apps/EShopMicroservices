
#### HTTP and HTTPs Porta for all the services 
|Service Name | Local Env| Docker | Docker Inside|
|-----|----|---|---|
|Catalog API | 5000- 5050 | 6000-6060 | 8080-8081 |
|Basket API | 5001- 5051 | 6001-6061 | 8080-8081 |
|Discount API | 5002- 5052 | 6002-6062 | 8080-8081 |
|Ordering API | 5003- 5053 | 6003-6063 | 8080-8081|


--------------------------
npx create-react-app eshop-app --template typescript-



-------------------------------------
## Tag images for docker repo

docker tag basketapi:latest sharadit/basketapi
docker tag catalogapi:latest sharadit/catalogapi
docker tag discountgrpc:latest sharadit/discountgrpc
docker tag yarpapigateway:latest sharadit/yarpapigateway
docker tag orderingapi:latest sharadit/orderingapi
docker tag shoppingweb:latest sharadit/shoppingweb


## Push Images to docker hub
docker push sharadit/basketapi
docker push sharadit/catalogapi
docker push sharadit/discountgrpc
docker push sharadit/yarpapigateway
docker push sharadit/orderingapi
docker push sharadit/shoppingweb



## Kubesctl list Pods, Services and Deployments

kubectl get deployments
kubectl get pods
kubectl get services


## Check logs of container


kubectl get pods
kubectl logs <pod_name> -c <container_name>
kubectl logs catalog-api-677f778455-6qmdn -c catalog-api



