//$http, $timeout e $interval nao precisa estar nos parametros, apenas se for utilizar
app.controller('sampleController', function($scope, $http, $timeout, $interval) {
	
});


//$http, $timeout e $interval nao precisa estar nos parametros, apenas se for utilizar
app.controller('teste1Controller', function($scope, $http, $timeout, $interval) {
	$http({
		method: "GET",
		url: "http://www.w3schools.com/angular/customers_mysql.php"
	}).then(function mySuccess (response) {

		$scope.nomes = response.data.records;

	}, function myError(response) {
		$scope.myHeader = response.statusText;
	});

	$scope.nome = "ale2";

	$scope.myHeader = "Hello World!";
  	$timeout(function () {
      		$scope.myHeader = "How are you today?";
  	}, 2000);

	$scope.theTime = new Date().toLocaleTimeString();
  	$interval(function () {
      		$scope.theTime = new Date().toLocaleTimeString();
  	}, 1000);

	$scope.count = 0;


    $scope.products = ["Milk", "Bread", "Cheese"];
    $scope.addItem = function () {
        $scope.products.push($scope.addMe);
    }

    $scope.removeItem = function (x) {
        $scope.products.splice(x, 1);
    }
});


app.controller('mainController', function($scope) {
(function($){
  $(function(){
    $('.parallax').parallax();
    $(".button-collapse").sideNav(); 
    $('.btnTrabalheConosco').sideNav({
      menuWidth: 300, // Default is 300
      edge: 'right', // Choose the horizontal origin
      closeOnClick: true, // Closes side-nav on <a> clicks, useful for Angular/Meteor
      draggable: true // Choose whether you can drag to open on touch screens
    });   
    $('#modal1').modal({
      dismissible: false, // Modal can be dismissed by clicking outside of the modal
      opacity: .7, // Opacity of modal background
      inDuration: 300, // Transition in duration
      outDuration: 200, // Transition out duration
      startingTop: '4%', // Starting top style attribute
      endingTop: '10%', // Ending top style attribute
      ready: function(modal, trigger) { // Callback for Modal open. Modal and trigger parameters available.
        alert("Ready");
        console.log(modal, trigger);
      },
      complete: function() { alert('Closed'); } // Callback for Modal close
    });
  });
})(jQuery);

$scope.teste = function () {
debugger;
        $scope.message = "Teste";
    };
});