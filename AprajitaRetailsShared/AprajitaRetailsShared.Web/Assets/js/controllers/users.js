//=========================================================================
// Project  :   Shared.Web.JavaScript.Controllers.core
// Model    :   users
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 3:00:08 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .controller('usersCtrl', ['Core', 'Alerts', 'Exceptions', 'Layouts', 'Modals',
            function (Core, Alerts, Exceptions, Layouts, Modals) {
                var Class = this;

                // Class main objects definition
                Class.Filter = {};
                Class.Object = {};

                // Class main collection definition
                Class.Collection = [];

                // Class collections definition
                Class.Enums = {};
                Class.Lists = {};
                Class.Maps = {};

                // Class authority definition
                Class.Permissions = null;
                Class.User = null;

                // Class logging definition
                Class.Logging = {
                    Enabled: true,
                    Location: 'users.js'
                };

                // Actions definition
                Class.ShowDelete = _ShowDelete;
                Class.ShowInsert = _ShowInsert;
                Class.ShowSelect = _ShowSelect;
                Class.ShowUpdate = _ShowUpdate;

                // Events definition
                Class.Refresh = _Refresh;

                // Methods definition
                Class.Clean = _Clean;
                Class.Delete = _Delete;
                Class.Insert = _Insert;
                Class.Select = _Select;
                Class.Update = _Update;
                Class.Save = _Save;

                // Layout definition
                Class.Layout = Layouts.Get('users');

                // Start definition
                _Start();

                // Start implementation
                function _Start() {
                    Modals.Loading();
                    Core.Configure('users as Usuários', Class);
                    Core.GetLoggedUser(function (User) {
                        Class.User = User;
                        Class.Permissions = User.Permissions;

                        _SelectAll();
                    });
                }

                // Actions implementation
                function _ShowDelete() {
                    Core.ShowDelete(Class);
                }

                function _ShowInsert() {
                    Core.ShowInsert(Class);
                }

                function _ShowSelect() {
                    Core.ShowSelect(Class);
                }

                function _ShowUpdate() {
                    Core.ShowUpdate(Class);
                }

                // Events implementation
                function _Refresh() {
                    Core.Refresh(Class, AfterRefresh);
                }

                // Methods implementation
                function _Clean() {
                    Core.Clean(Class);
                }

                function _Delete() {
                    Core.Delete(Class);
                }

                function _Insert() {
                    Core.Insert(Class);
                }

                function _Select() {
                    Core.Select(Class);
                }

                function _Update() {
                    Core.Update(Class);
                }

                function _Save() {
                    if (Class.Object) {
                        if (Class.Object.Id) {
                            _Update();
                        }
                        else {
                            _Insert();
                        }
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Controllers.Methods.Save.NoObject);
                    }
                }

                // Callbacks implementation
                function AfterRefresh(result) {
                    if (result && result.length > 0) {
                        Class.Collection = result;
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Controllers.Callbacks.NoResult);
                    }

                    Core.Render(Class);
                }
            }
        ]);
})();