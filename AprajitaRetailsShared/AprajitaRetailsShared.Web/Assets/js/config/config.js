//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.config
// Model    :   config
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 3:10:30 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .config(['$stateProvider', '$urlRouterProvider', '$httpProvider',
            function ($stateProvider, $urlRouterProvider, $httpProvider) {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'config.js'
                    }
                };

                $stateProvider
                    .state('shared', {
                        abstract: true,
                        url: "/shared",
                        templateUrl: "views/shared.html"
                    })
                    .state('shared.errors', {
                        url: "/errors",
                        templateUrl: "views/errors.html",
                        params: {
                            message: null
                        },
                        controller: 'errorsCtrl',
                        controllerAs: 'errorsCtrl'
                    })
                    .state('shared.home', {
                        url: "/home",
                        templateUrl: "views/home.html",
                        controller: 'homeCtrl',
                        controllerAs: 'homeCtrl'
                    })
                    .state('shared.logs', {
                        url: "/logs",
                        templateUrl: "views/logs.html",
                        controller: 'logsCtrl',
                        controllerAs: 'logsCtrl'
                    })
                    .state('shared.maintenance', {
                        url: "/maintenance",
                        templateUrl: "views/extras/maintenance.html",
                        controller: 'maintenanceCtrl',
                        controllerAs: 'maintenanceCtrl'
                    })
                    .state('shared.menus', {
                        url: "/menus",
                        templateUrl: "views/menus.html",
                        controller: 'menusCtrl',
                        controllerAs: 'menusCtrl'
                    })
                    .state('shared.notifications', {
                        url: "/notifications",
                        templateUrl: "views/notifications.html",
                        controller: 'notificationsCtrl',
                        controllerAs: 'notificationsCtrl'
                    })
                    .state('shared.settings', {
                        url: "/settings",
                        templateUrl: "views/settings.html",
                        controller: 'settingsCtrl',
                        controllerAs: 'settingsCtrl'
                    })
                    .state('shared.submenus', {
                        url: "/submenus",
                        templateUrl: "views/submenus.html",
                        controller: 'submenusCtrl',
                        controllerAs: 'submenusCtrl'
                    })
                    .state('shared.users', {
                        url: "/users",
                        templateUrl: "views/users.html",
                        controller: 'usersCtrl',
                        controllerAs: 'usersCtrl'
                    });

                $urlRouterProvider
                    .otherwise('/shared/home');

                $httpProvider
                    .interceptors
                    .push('Interceptor');
            }
        ]);
})();