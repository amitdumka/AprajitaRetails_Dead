//=========================================================================
// Project  :   Shared.Web.Layout.Exceptions.Assets.js.core
// Model    :   exceptions
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 4:33:28 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Exceptions', [
            function () {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'exceptions.js'
                    }
                };

                // Class exceptions map definition
                Class.Shared = {
                    Config: {
                    },
                    Controllers: {
                        Callbacks: {
                            NoResult: {
                                Message: {
                                    'pt-br': 'O resultado obtido não contém dados ou os dados obtidos não são válidos para esta operação',
                                    'en-us': 'The obtained result does not contains data or the data obtained are not valid for this operation'
                                }
                            }
                        },
                        Class: {
                        },
                        Start: {
                        },
                        Actions: {
                        },
                        Events: {
                        },
                        Methods: {
                            Clean: {
                            },
                            Delete: {
                            },
                            Insert: {
                            },
                            Select: {
                            },
                            Update: {
                            },
                            Save: {
                                NoObject: {
                                    Message: {
                                        'pt-br': 'O elemento obrigatório para ser criado/modificado não foi identificado e a operação não pôde ser completada',
                                        'en-us': 'The required element to be created/changed was not identified and the operation cannot be completed'
                                    }
                                }
                            }
                        },
                        Security: {
                            BadUsernameOrPassword: {
                                Message: {
                                    'pt-br': 'Os dados fornecidos são inválidos',
                                    'en-us': 'Invalid username or password'
                                }
                            }
                        }
                    },
                    Core: {
                        Layouts: {
                            Actions: {
                                Get: {
                                    NoLayouts: {
                                        Message: {
                                            'pt-br': 'O layout solicitado não foi encontrado na coleção de layouts definida no sistema',
                                            'en-us': 'The requested layout was not found in the layouts collection defined in the system'
                                        },
                                        Details: {
                                            'pt-br': 'O desenvolvedor pode ter esquecido de adicionar o layout solicitado à coleção de layouts do sistema',
                                            'en-us': 'The developer can missed to add the requested layout in the layouts collection of the system'
                                        }
                                    }
                                }
                            }
                        }
                    },
                    Init: {
                    },
                    Interceptor: {
                    },
                    Main: {
                        Forms: {
                            EmptyFields: {
                                Message: {
                                    'pt-br': 'Existem campos obrigatórios não preenchidos',
                                    'en-us': 'There are empty required fields'
                                }
                            }
                        },
                        General: {
                            NoErrors: {
                                Message: {
                                    'pt-br': 'Não há erros para serem exibidos',
                                    'en-us': 'No errors to be shown'
                                }
                            }
                        }
                    },
                    Modals: {
                    },
                    Navbar: {
                    },
                };

                // External implementation
                return Class;
            }
        ]);
})();