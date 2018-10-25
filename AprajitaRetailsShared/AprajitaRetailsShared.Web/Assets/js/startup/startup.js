//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.startup
// Model    :   startup
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
        .controller('startupCtrl', ['GenericService', 'AlertsService', 'ModalsService',
            function (GenericService, AlertsService, ModalsService) {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'startup.js'
                    }
                };

                // Actions definition
                Class.Show = _Show;

                // Events definition
                Class.Handle = _Handle;

                // Methods definition
                Class.Error = _Error;
                Class.Inform = _Inform;
                Class.Success = _Success;
                Class.Warning = _Warning;

                // Actions implementation
                function _Show(message, type, timeout, style, position) {
                    var header = '<p class="font-montserrat hint-text bold upper">Mensagem do Sistema</p>';;
                    var content = _Handle(message);

                    switch (type) {
                        case 'alert':
                            type = 'warning';
                            break;
                        case 'danger':
                            type = 'danger';
                            break;
                        case 'error':
                            type = 'danger';
                            break;
                        case 'info':
                            type = 'info';
                            break;
                        case 'success':
                            type = 'success';
                            break;
                        case 'warning':
                            type = 'warning';
                            break;
                        default:
                            type = 'info';
                            break;
                    }

                    if (!timeout || timeout === null) {
                        timeout = 5000;
                    }

                    if (!style || style === null) {
                        style = 'flip';
                    }

                    if (!position || position === null) {
                        position = 'bottom-right';
                    }

                    $('body').pgNotification({
                        message: header + content,
                        type: type,
                        timeout: timeout,
                        style: style,
                        position: position
                    }).show();
                }

                // Events implementation
                function _Handle(data) {
                    var content;
                    if (data && data !== null) {
                        if (typeof data !== 'string') {
                            if (data.responseText) {
                                data = data.responseText;
                                if (data.toString().indexOf('<title>') != -1) {
                                    var substring = '';
                                    var start = data.indexOf('<title>');
                                    substring = data.substr(start + 7, data.length);
                                    var finish = substring.indexOf('</title>');
                                    substring = substring.substr(0, finish);
                                    content = substring;
                                }
                                else {
                                    data = JSON.parse(data);
                                    if (data.ExceptionMessage) {
                                        if (data.InnerException
                                            && data.InnerException.ExceptionMessage) {
                                            content = data.InnerException.ExceptionMessage;
                                        }
                                        else {
                                            content = data.ExceptionMessage;
                                        }
                                    }
                                    else if (data.MessageDetail) {
                                        content = data.MessageDetail;
                                    }
                                }
                            }
                            else if (data.Message) {
                                content = data.Message;
                                if (data.Details) {
                                    content += '\n\n' + data.Details;
                                    if (data.Solution) {
                                        content += '\n\n' + data.Solution;
                                    }
                                }
                            }
                            else {
                                if (data.ExceptionMessage) {
                                    if (data.InnerException
                                        && data.InnerException.ExceptionMessage) {
                                        if (data.InnerException.ExceptionMessage === data.ExceptionMessage
                                            && data.InnerException.InnerException) {
                                            content = data.InnerException.InnerException.ExceptionMessage;
                                        }
                                        else {
                                            content = data.InnerException.ExceptionMessage;
                                        }
                                    }
                                    else {
                                        content = data.ExceptionMessage;
                                    }
                                }
                                else if (data.MessageDetail) {
                                    content = data.MessageDetail;
                                }
                                else if (data.Message) {
                                    content = data.Message;
                                }
                            }
                        }
                        else {
                            content = data;
                        }
                    }
                    else {
                        content = 'A solicitação foi cancelada pelo servidor.';
                    }

                    content = content.
                        replace('\r\n\r\n', '<br><br>').
                        replace('\r\n', '<br>').
                        replace('\n\n', '<br><br>').
                        replace('\n', '<br>');

                    return content;
                }

                // Methods implementation
                function _Error(data) {
                    _Show(data, 'danger', 6000);
                }

                function _Inform(data) {
                    _Show(data, 'info', 4000);
                }

                function _Success(data) {
                    _Show(data, 'success', 3000);
                }

                function _Warning(data) {
                    _Show(data, 'warning', 5000);
                }

                // External implementation
                return Class;
            }]);
})();