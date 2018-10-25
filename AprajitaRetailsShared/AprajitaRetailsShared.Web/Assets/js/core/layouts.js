//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   layouts
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 5:16:26 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Layouts', ['Alerts', 'Exceptions',
            function (Alerts, Exceptions) {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'layouts.js'
                    }
                };

                // Class templates definition
                Class.Templates = {
                    Checkbox: function (value) {
                        return '<div class="checkbox check-primary p-l-0">' +
                            '<input id="' + value + '" class="checkbox check-primary fs-10" type="checkbox" />' +
                            '<label for="' + value + '" class="inline"></label>' +
                            '</div>';
                    },
                    Icon: function (value) {
                        return '<i class="' + value + '"></i> ' + value;
                    },
                    Label: function (style, value) {
                        return '<span class="label label-' + style + '">' + value + '</>';
                    }
                };

                // Class layouts definition
                Class.Layouts = {
                    'errors': {
                    },
                    'home': {
                    },
                    'logs': {
                        Columns: [
                            { title: "#", sortable: false },
                            { title: "Nome", sortable: true },
                            { title: "Url", sortable: false },
                            { title: "Ícone", sortable: false },
                            { title: "Ordem", sortable: true },
                            { title: "Visível", sortable: true }
                        ],
                        Order: [[1, 'asc']],
                        Parse: function (entity) {
                            return [
                                Class.Templates.Checkbox(entity.Id),
                                entity.Name,
                                entity.Url,
                                Class.Templates.Icon(entity.Icon),
                                entity.Sequence,
                                Class.Templates.Label((entity.Status ? 'success' : 'danger'), (entity.Status ? 'Sim' : 'Não'))
                            ]
                        },
                        Source: []
                    },
                    'maintenance': {
                    },
                    'menus': {
                    },
                    'notifications': {
                    },
                    'security': {
                    },
                    'settings': {
                    },
                    'submenus': {
                    },
                    'users': {
                    },
                };

                // Actions definition
                Class.Get = _Get;

                // Actions implementation
                function _Get(layout) {
                    if (Class.Layouts[layout]) {
                        return Class.Layouts[layout];
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Layouts.Actions.Get.NoLayouts);
                    }
                }

                // External implementation
                return Class;
            }]);
})();