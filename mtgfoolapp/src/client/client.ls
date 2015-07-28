_ = require 'prelude-ls'

homeController = ($scope) ->
    $scope.name = 'home'

apiFactory = ($resource,Data,ErrorHandler) ->
  do
    importCollection: (data,cb) ->
      $resource '/api/v1/collections/import', null
      .save {}, data, cb, ErrorHandler

    getCards: (cb) ->
      $resource '/api/v1/cards', null
      .query {}, {}, cb, ErrorHandler

config = ($routeProvider) ->
  $routeProvider

  .when '/home', do
    templateUrl: 'home.html'
    controller: 'homeController'

  .otherwise do
    redirectTo: '/home'

app = angular.module 'app',[
  'ngResource'
  'ngRoute'
  'ui.bootstrap'
]

app.factory 'Api',['$resource','Data','ErrorHandler',apiFactory]
app.controller 'homeController', ['$scope',homeController]

app.config ['$routeProvider',config]
