//==============================================================================
// Project  :   Shared.Web.JavaScript.Controllers.core.blocks
// Model    :   quickview
//==============================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//==============================================================================
// Created  :   4/11/2017 3:01:33 PM
//==============================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .controller('quickviewCtrl', ['GenericService', 'AlertsService', 'ModalsService',
            function (GenericService, AlertsService, ModalsService) {
                var vm = this;

                //Api definition
                vm.Api = 'api/quickview';
                vm.Table = 'table-quickview';

                // Page definition
                vm.Action = null;
                vm.Locked = false;
                vm.Methods = null;
                vm.Title = 'Título da Página';

                // Page parameters
                // vm.Hiding = false;

                // Page variables definition
                vm.New = {};

                // Page elements array definition
                vm.Array = [];

                // Enums lists variables definition
                // vm.Types = [];

                // Lists variables definition
                // vm.Items = [];

                // Maps variables definition
                // vm.ItemsByType = [];

                // Logged user definition
                vm.LoggedUser = {};

                // Actions definition
                vm.ShowCreate = _ShowCreate;
                vm.ShowDelete = _ShowDelete;
                vm.ShowRead = _ShowRead;
                vm.ShowUpdate = _ShowUpdate;

                // Events definition
                // vm.ItemChanged = _ItemChanged;

                // Methods definition
                vm.Clean = _Clean;
                vm.Delete = _Delete;
                vm.Insert = _Insert;
                vm.SelectAll = _SelectAll;
                vm.Update = _Update;
                vm.Save = _Save;

                // Initialization definition
                Initialize();

                // Initialization implementation
                function Initialize() {
                    ModalsService.Show('loading');

                    GenericService.GetLoggedUser(function (user) {
                        // GenericService.SelectAll('api/items', user.Id, function (items) {
                        //     vm.Items = items;

                        //     _SelectAll();
                        // });

                        vm.LoggedUser = user;
                        vm.Methods = user.Methods;

                        _SelectAll();
                    });
                }

                // Actions implementation
                function _ShowCreate() {
                    GenericService.ShowCreate(vm);
                }

                function _ShowDelete() {
                    GenericService.ShowDelete(vm);
                }

                function _ShowRead() {
                    GenericService.ShowRead(vm);
                }

                function _ShowUpdate() {
                    GenericService.ShowUpdate(vm);
                }

                // Methods implementation
                function _Clean() {
                    GenericService.Clean(vm);
                }

                function _Delete() {
                    GenericService.Delete(vm, onSuccess);
                }

                function _Insert() {
                    GenericService.Insert(vm, vm.New, onSuccess);
                }

                function _SelectAll() {
                    GenericService.SelectAll(vm.Api, vm.LoggedUser.Id, onSuccess);
                }

                function _Update(id) {
                    GenericService.Update(vm, vm.New, onSuccess);
                }

                function _Save() {
                    if (vm.New) {
                        if (vm.New.Id) {
                            _Update();
                        }
                        else {
                            _Insert();
                        }
                    }
                }

                // Parser implementation
                function _Parse(entity) {
                    return [
                        '<div class="checkbox check-primary p-l-0">' +
                        '<input id="' + entity.Id + '" class="checkbox check-primary fs-10" type="checkbox" />' +
                        '<label for="' + entity.Id + '" class="inline"></label>' +
                        '</div>',
                        entity.Title,
                        // entity.ItemText
                    ];
                }

                // Callbacks implementation
                function onSuccess(data) {
                    vm.Array = data;

                    var sources = [];
                    if (data) {
                        data.forEach(function (entity) {
                            var row = _Parse(entity);
                            sources.push(row);
                        });
                    }

                    var options = {
                        table: vm.Table,
                        title: vm.Title,
                        columns: [
                            { title: "#", sortable: false },
                            { title: "Título", sortable: true }
                            // { title: "Item", sortable: false }
                        ],
                        data: sources,
                        order: [[1, 'asc']]
                    };

                    GenericService.Render(options);
                }
            }]);
})();