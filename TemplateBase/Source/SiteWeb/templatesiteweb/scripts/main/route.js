app.config(function($routeProvider) {
	$routeProvider
	.when("/", {
		templateUrl: "/view/main/index.html",
		controller: "mainController"
	})
	.when("/sample", {
		templateUrl: "/view/sample/index.html",
		controller: "sampleController"
	})
	.otherwise({ redirectTo: '/'});
});