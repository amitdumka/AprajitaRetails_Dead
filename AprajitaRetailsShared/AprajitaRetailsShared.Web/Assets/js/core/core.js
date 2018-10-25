//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   core
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 1:08:59 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Core', ['$http', '$state', '$timeout', 'Alerts', 'Exceptions', 'Modals', 'Tables',
            function ($http, $state, $timeout, Alerts, Exceptions, Modals, Tables) {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'core.js'
                    }
                };

                // Class parameters definition
                Class.Notifications = true;
                Class.Search = false;

                // Actions definition
                Class.HideActions = _HideActions;
                Class.HideMarkAll = _HideMarkAll;
                Class.HideMultiple = _HideMultiple;
                Class.ShowActions = _ShowActions;
                Class.ShowDeleteMarked = _ShowDeleteMarked;
                Class.ShowMarkAll = _ShowMarkAll;
                Class.ShowMultiple = _ShowMultiple;

                // Events definition
                Class.InitializeKeyboard = _InitializeKeyboard;
                Class.StopKeyboard = _StopKeyboard;

                // Methods definition
                Class.Bind = _Bind;
                Class.Configure = _Configure;
                Class.Clean = _Clean;
                Class.Delete = _Delete;
                Class.DeleteAll = _DeleteAll;
                Class.DeselectAll = _DeselectAll;
                Class.First = _First;
                Class.Get = _Get;
                Class.GetCurrentDate = _GetCurrentDate;
                Class.GetCurrentDatetime = _GetCurrentDatetime;
                Class.GetCurrentTime = _GetCurrentTime;
                Class.GetLoggedUser = _GetLoggedUser;
                Class.GetLoggedToken = _GetLoggedToken;
                Class.GetSelectedCheckboxes = _GetSelectedCheckboxes;
                Class.GetSelectedItem = _GetSelectedItem;
                Class.Insert = _Insert;
                Class.InsertAll = _InsertAll;
                Class.Post = _Post;
                Class.Select = _Select;
                Class.SelectAll = _SelectAll;
                Class.SelectAllByAction = _SelectAllByAction;
                Class.SelectAllByFilters = _SelectAllByFilters;
                Class.SignIn = _SignIn;
                Class.SignOut = _SignOut;
                Class.Storage = _Storage;
                Class.Unbind = _Unbind;
                Class.Update = _Update;
                Class.Upload = _Upload;
                Class.Render = _Render;

                // Actions implementation
                function _HideActions() {
                    $('#navbar-refresh').removeClass('hidden');
                    $('#navbar-create').removeClass('hidden');

                    $('#navbar-read').addClass('hidden');
                    $('#navbar-update').addClass('hidden');
                    $('#navbar-delete').addClass('hidden');
                    $('#navbar-clean').addClass('hidden');

                    if ($('#navbar [data-action="custom"]')) {
                        $('#navbar [data-action="custom"]').each(function () {
                            $(this).addClass('hidden');
                        });
                    }

                    _ShowMarkAll();
                }

                function _HideMarkAll() {
                    $('#navbar-selectall').addClass('hidden');
                }

                function _HideMultiple() {
                    $('#navbar-delete').addClass('hidden');
                    $('#navbar-selectall').addClass('hidden');
                }

                function _ShowActions() {
                    $('#navbar-refresh').addClass('hidden');
                    $('#navbar-create').addClass('hidden');

                    $('#navbar-read').removeClass('hidden');
                    $('#navbar-update').removeClass('hidden');
                    $('#navbar-delete').removeClass('hidden');
                    $('#navbar-clean').removeClass('hidden');

                    if ($('#navbar [data-action="custom"]')) {
                        $('#navbar [data-action="custom"]').each(function () {
                            $(this).removeClass('hidden');
                        });
                    }
                }

                function _ShowDeleteMarked() {
                    $('#navbar-delete').removeClass('hidden');
                }

                function _ShowMarkAll() {
                    $('#navbar-selectall').removeClass('hidden');
                }

                function _ShowMultiple() {
                    $('#navbar-refresh').addClass('hidden');
                    $('#navbar-create').addClass('hidden');
                    $('#navbar-read').addClass('hidden');
                    $('#navbar-update').addClass('hidden');

                    $('#navbar-delete').removeClass('hidden');
                    $('#navbar-selectall').removeClass('hidden');
                    $('#navbar-clean').removeClass('hidden');
                }

                // Events implementation
                var keysPressed = {};
                document.addEventListener('keydown', function (e) {
                    keysPressed[e.keyCode] = true;
                    _InitializeKeyboard();

                    _StopKeyboard();
                }, false);

                document.addEventListener('keyup', function (e) {
                    keysPressed[e.keyCode] = false;

                    _StopKeyboard();
                }, false);

                function _InitializeKeyboard() {
                    // Trigger header-filters (Alt + G)
                    if (keysPressed["18"] && keysPressed["71"]) {
                        if (Modals.Exists('filters')) {
                            Modals.Show('filters');
                        }
                    }
                    // Trigger navbar-selectall (Alt + A)
                    else if (keysPressed["18"] && keysPressed["65"]) {
                        if ($('#navbar-selectall')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-selectall').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-refresh (Alt + S)
                    else if (keysPressed["18"] && keysPressed["83"]) {
                        if ($('#navbar-refresh')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-refresh').trigger('click');
                                $('#navbar-clean').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-create (Alt + N)
                    else if (keysPressed["18"] && keysPressed["78"]) {
                        if ($('#navbar-create')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-create').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-update (Alt + U)
                    else if (keysPressed["18"] && keysPressed["85"]) {
                        if ($('#navbar-update')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-update').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-delete (Alt + X)
                    else if (keysPressed["18"] && keysPressed["88"]) {
                        if ($('#navbar-delete')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-delete').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-read (Alt + R)
                    else if (keysPressed["18"] && keysPressed["82"]) {
                        if ($('#navbar-read')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-read').trigger('click');
                            }
                        }
                    }
                    // Trigger navbar-clean (Alt + C)
                    else if (keysPressed["18"] && keysPressed["67"]) {
                        if ($('#navbar-clean')) {
                            if (!Modals.IsShown('create')) {
                                $('#navbar-clean').trigger('click');
                            }
                        }
                    }
                }

                function _StopKeyboard() {
                    $timeout(function () {
                        keysPressed = [];
                    }, 1000);
                }

                // Methods implementation
                function _Bind(selector, event, callback) {
                    $(selector).on(event, function (ev) {
                        if (typeof callback === 'function') {
                            callback(ev, ev.target);
                        }
                    });
                }

                function _Configure(config, controller) {
                    if (config && controller) {
                        if (typeof config === 'string') {
                            var state = null;
                            var title = null;
                            if (config.indexOf('as') !== -1) {
                                var parameters = config.split('as');
                                if (parameters && parameters.length > 1) {
                                    state = parameters[0];
                                    title = parameters[1];
                                }
                                else {
                                    Alerts.Error(Exceptions.Shared.Core.Methods.Configure.InvalidParameters);
                                    return;
                                }
                            }

                            controller.Api = 'api/' + state;
                            controller.Table = 'table-' + state;

                            if (title && title !== null) {
                                controller.Title = title;
                            }
                            else {
                                Alerts.Error(Exceptions.Shared.Core.Methods.Configure.InvalidTitle);
                                return;
                            }
                        }
                        else {
                        }
                    }
                    else if (!controller) {
                        Alerts.Error(Exceptions.Shared.Core.Methods.Configure.InvalidController);
                        return;
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Core.Methods.Configure.InvalidConfiguration);
                        return;
                    }
                }

                function _Clean(controller, callback) {
                    controller.New = {};
                    Modals.Clean();

                    if (typeof callback === 'function') {
                        callback();
                    }
                }

                function _Delete(controller, success, failure) {
                    _GetSelectedCheckboxes(controller.Table, function (data) {
                        if (!data || data.length <= 0) {
                            Alerts.Error('Não há nenhum item selecionado para ser excluído!');
                            return;
                        }
                        else if (data.length === 1) {
                            _DeleteById(controller, data[0], success, failure);
                        }
                        else if (data.length > 1) {
                            _DeleteAll(controller, data, success, failure);
                        }
                    });
                }

                function _DeleteById(controller, id, success, failure) {
                    Modals.Hide('delete');
                    Modals.Show('loading');
                    $http.delete(controller.Api + '/delete/' + id).
                        success(function (data) {
                            var ids = [];
                            ids.push(id);

                            _HideActions();
                            onDeleteAll(controller.Array, ids, 1, success);
                        }).
                        error(function (error) {
                            Modals.Hide('loading');
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _DeleteAll(controller, source, success, failure) {
                    Modals.Hide('delete');
                    Modals.Show('loading');
                    $http.post(controller.Api + '/deleteall/', source).
                        success(function (data) {
                            var ids = [];
                            for (var i = 0; i < source.length; i++) {
                                ids.push(source[i]);
                            }

                            _HideActions();
                            onDeleteAll(controller.Array, ids, source.length, success);
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _DeselectAll(success, failure) {
                    if ($('#navbar-clean')) {
                        $('#navbar-clean').trigger('click');
                    }
                }

                function _First(url, success, failure) {
                    $http.get(url + '/select/').
                        success(function (data) {
                            Modals.Hide('loading');
                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _Get(url, action, source, success, failure) {
                    $http.get(url + '/' + action + '/' + source).
                        success(function (data) {
                            Modals.Hide('loading');
                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            Modals.Hide('loading');
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _GetCurrentDate() {
                    var date = new Date();
                    return ''
                        + (date.getDate() < 10 ? '0' + date.getDate() : date.getDate()) + '/'
                        + ((date.getMonth() + 1) < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1)) + '/'
                        + date.getFullYear()
                }

                function _GetCurrentDatetime() {
                    return _GetCurrentDate() + ' ' + _GetCurrentTime();
                }

                function _GetCurrentTime() {
                    var date = new Date();
                    return ''
                        + (date.getHours() < 10 ? '0' + date.getHours() : date.getHours()) + ':'
                        + (date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes()) + ':'
                        + (date.getSeconds() < 10 ? '0' + date.getSeconds() : date.getSeconds())
                }

                function _GetLoggedUser(success, failure) {
                    var username = localStorage.getItem('username');
                    if (username && username !== null) {
                        $http.get('api/users/selectbylogin/' + id).
                            success(function (data) {
                                Modals.Hide('loading');
                                if (data && data.ClassificationType) {
                                    data.Permissions = data.ClassificationType === 1 ?
                                        'crud' : data.ClassificationType === 2 ? 'cru' : 'r';
                                }

                                if (typeof success === 'function') {
                                    success(data);
                                }

                                return data;
                            }).
                            error(function (error) {
                                onFailure(error);
                                if (typeof failure === 'function') {
                                    failure(error);
                                }
                            });
                    }
                    else {
                        window.location = 'login.html';
                    }
                }

                function _GetLoggedToken(success) {
                    var token = localStorage.getItem('token');
                    if (typeof success === 'function') {
                        success(token);
                    }

                    return token;
                }

                function _GetSelectedCheckboxes(table, success) {
                    var ids = [];
                    $('#' + table + ' tbody tr td .checkbox input[type="checkbox"]:checked').each(function () {
                        var id = $(this).attr('id');
                        if (id) {
                            ids.push(id);
                        }
                    });

                    if (typeof success === 'function') {
                        success(ids);
                    }

                    return ids;
                }

                function _GetSelectedItem(id, array, callback) {
                    if (id && array && array.length > 0) {
                        var result = $.grep(array, function (e) {
                            return e.Id === id;
                        });

                        if (result) {
                            callback(result[0]);
                            return;
                        }
                    }

                    Alerts.Error('O item selecionado não foi encontrado ou pode ter sido removido!');
                    callback(null);
                }

                function _Insert(controller, source, success, failure) {
                    $http.post(controller.Api + '/insert/', source).
                        success(function (data) {
                            var result = [];
                            result.push(data);

                            _HideActions();
                            onInsertAll(controller.Array, result, 1, success);
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _InsertAll(controller, source, success, failure) {
                    $http.post(controller.Api + '/insertall/', source).
                        success(function (data) {
                            _HideActions();
                            onInsertAll(controller.Array, data, source.length, success);
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _Post(url, action, source, success, failure) {
                    $http.post(url + '/' + action, source).
                        success(function (data) {
                            _HideActions();

                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error, url + '/' + action);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _Render(controller) {
                    if (controller && controlle.Collection && controller.Layout) {
                        var source = [];
                        if (typeof controller.Layout.Parse === 'function') {
                            controller.Collection.forEach(function (entity) {
                                var convertion = controller.Layout.Parse(entity);
                                if (convertion) {
                                    source.push(convertion);
                                }
                            });

                            controller.Layout.Source = source;
                            Tables.Create(controller.Layout);
                        }
                        else {
                            Alerts.Error(Exceptions.Shared.Core.Methods.Render.ParserNotImplemented);
                            return;
                        }
                    }
                    else if (!controller.Collection) {
                        Alerts.Error(Exceptions.Shared.Core.Methods.Render.InvalidCollection);
                        return;
                    }
                    else if (!controller.Layout) {
                        Alerts.Error(Exceptions.Shared.Core.Methods.Render.InvalidLayout);
                        return;
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Core.Methods.Render.InvalidController);
                        return;
                    }
                }

                function _Select(url, id, success, failure) {
                    $http.get(url + '/select/' + id).
                        success(function (data) {
                            Modals.Hide('loading');
                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _SelectAll(url, profile, success, failure) {
                    $http.get(url + '/selectallbyprofile/' + profile).
                        success(function (data) {
                            Modals.Hide('loading');
                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _SelectAllByAction(url, action, id, success, failure) {
                    $http.get(url + '/' + action + '/' + id).
                        success(function (data) {
                            Modals.Hide('loading');
                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _SelectAllByFilters(url, filters, success, failure) {
                    $http.post(url + '/selectallbyfilters/', filters).
                        success(function (data) {
                            Modals.Hide('loading');
                            _HideActions();

                            if (typeof success === 'function') {
                                success(data);
                            }
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _IsSigned(controller, callback) {
                    _Post('api/security', 'isauthenticated', controller.Object, callback);
                }

                function _SignIn(controller, callback) {
                    _Post('api/security', 'authenticate', controller.Object, callback);
                }

                function _SignOut() {
                    window.localStorage.clear();
                    console.log('Os dados da sessão atual foram limpos com sucesso.');

                    window.location = 'login.html';
                }

                function _Storage(key, value) {
                    var current;
                    if (key) {
                        current = localStorage.getItem(key);
                        if (current) {
                            if (value !== undefined) {
                                localStorage.setItem(key, value);
                                current = value;
                            }
                        }
                        else {
                            if (value !== undefined) {
                                localStorage.setItem(key, value);
                                current = value;
                            }
                        }
                    }

                    return current;
                }

                function _Unbind(selector, event) {
                    $(selector).off(event);
                }

                function _Update(controller, source, success, failure) {
                    $http.put(controller.Api + '/update/', source).
                        success(function (data) {
                            _HideActions();
                            onUpdate(controller.Array, success);
                        }).
                        error(function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        });
                }

                function _Upload(url, season, source, success, failure) {
                    $.ajax({
                        url: url + '/upload/' + season,
                        data: source,
                        type: 'POST',
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            onUpload();
                            if (typeof success === 'function') {
                                success(data);
                            }
                        },
                        error: function (error) {
                            onFailure(error);
                            if (typeof failure === 'function') {
                                failure(error);
                            }
                        }
                    });
                }

                // Callbacks implementation
                function onDeleteAll(array, ids, length, callback) {
                    Alerts.Success(length + ' registro(s) excluído(s) com sucesso!');
                    if (array && array.length > 0) {
                        if (ids && ids.length > 0) {
                            for (var i = 0; i < ids.length; i++) {
                                var index = array.findIndex(row => row.Id === ids[i]);
                                if (index === -1) {
                                    Alerts.Error('O item selecionado não foi encontrado ou pode ter sido removido!');
                                    return;
                                }

                                array.splice(index, 1);
                            }

                            if (typeof callback === 'function') {
                                callback(array);
                            }
                        }
                    }

                    Modals.Hide('loading');
                    Modals.Hide('delete');
                }

                function onInsertAll(array, data, length, callback) {
                    if (!array || array.length <= 0) {
                        array = [];
                    }

                    if (data && data.length > 0) {
                        for (var i = 0; i < data.length; i++) {
                            array.push(data[i]);
                        }
                    }

                    if (typeof callback === 'function') {
                        callback(array);
                    }

                    Alerts.Success(length + ' registro(s) salvo(s) com sucesso!');
                    Modals.Hide('loading');
                    Modals.Hide('create');
                }

                function onUpdate(array, callback) {
                    if (typeof callback === 'function') {
                        callback(array);
                    }

                    Alerts.Success('Registro(s) atualizado(s) com sucesso!');
                    Modals.Hide('create');
                }

                function onUpload() {
                    Modals.Hide('loading');
                    Modals.Hide('create');
                }

                function onFailure(error, url) {
                    Modals.Hide('loading');
                    Modals.Hide('delete');

                    if (typeof error === 'object') {
                        if (error.Message) {
                            if (error.MessageDetail) {
                                Alerts.Error(error.Message + '\n\n' + error.MessageDetail);
                            }
                            else {
                                Alerts.Error(error.Message);
                            }
                        }
                        else {
                            Alerts.Error(error);
                        }
                    }
                    else if (typeof error === 'string') {
                        if (error.indexOf('html') !== -1 && error.indexOf('404') !== -1) {
                            if (url && url !== null) {
                                Alerts.Error('A página relacionada à url informada não foi encontrada ou não é válida para esta operação!\n\nUrl: ' + url);
                            }
                            else {
                                Alerts.Error('A página relacionada à url informada não foi encontrada ou não é válida para esta operação!');
                            }
                        }
                        else {
                            Alerts.Error(error);
                        }
                    }
                }

                // External implementation
                return Class;
            }
        ]);
})();