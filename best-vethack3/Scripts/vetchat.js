var vetchat = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {
        apiPrefix: "http://localhost:1552"
    }
    , ui: {}

};
vetchat.moduleOptions = {
    APPNAME: "VetchatApp"
        , extraModuleDependencies: []
        , runners: []
        , page: vetchat.page//we need this object here for later use
}


vetchat.layout.startUp = function () {

    console.debug("vetchat.layout.startUp");

    //this does a null check on vetchat.page.startUp
    if (vetchat.page.startUp) {
        console.debug("vetchat.page.startUp");
        vetchat.page.startUp();
    }

    if (vetchat.layout.greeting) {
        vetchat.layout.greeting();
        $('#logout').on('click', vetchat.page.handlers.logout);
    }
};
vetchat.APPNAME = "VetchatApp";//legacy



$(document).ready(vetchat.layout.startUp);