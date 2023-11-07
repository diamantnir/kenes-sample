app.controller("kenesCtrl", function ($scope,$http) {

    $scope.url="https://localhost:44343/Kenes"
    $scope.isTrue=false;
    
    $scope.getToken = function () {
        var url = $scope.url+'/gettoken';

        $http.get(url)
            .then(function (response) {
                // Request successful
                $scope.getOrders(response.data);
                localStorage.token = response.data;
            })
            .catch(function (error) {
                // Request failed
                console.error('Error:', error);
            });
        }

        $scope.getOrders = function (token) {
            var url = $scope.url+'/getorders?token='+token;
    
            $http.get(url)
                .then(function (response) {
                    $scope.resp=[];
                    for(let i=0;i<response.data.length;i++)
                    {
                        var obj = { number: response.data[i] };
                         $scope.resp.push(obj);

                    }
                  
                })
                .catch(function (error) {
                    // Request failed
                    console.error('Error:', error);
                });
            }


            $scope.orderDetails = function (id) {
                var url = $scope.url+'/OrderDetails?token='+localStorage.token+"&id="+id.number;
        
                $http.get(url)
                    .then(function (response) {
                        $scope.isTrue=true;
                        $scope.details=response.data;
                    })
                    .catch(function (error) {
                        // Request failed
                        console.error('Error:', error);
                    });
                } 

                $scope.closePopUp = function () {
                    $scope.isTrue=false;
                    } 


                


    $scope.getToken();
   
   
});