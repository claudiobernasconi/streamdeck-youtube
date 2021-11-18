// global websocket, used to communicate from/to Stream Deck software
// as well as some info about our plugin, as sent by Stream Deck software 
var websocket = null,
    uuid = null,
    inInfo = null,
    actionInfo = {},
    settingsModel = {
        ApiKey: '',
        ChannelId: ''
    };

function connectElgatoStreamDeckSocket(inPort, inUUID, inRegisterEvent, inInfo, inActionInfo) {
    uuid = inUUID;
    actionInfo = JSON.parse(inActionInfo);
    inInfo = JSON.parse(inInfo);
    websocket = new WebSocket('ws://localhost:' + inPort);

    //initialize values
    if (actionInfo.payload.settings.settingsModel) {
        settingsModel.ApiKey = actionInfo.payload.settings.settingsModel.ApiKey;
        settingsModel.ChannelId = actionInfo.payload.settings.settingsModel.ChannelId;
    }

    document.getElementById('txtApiKeyValue').value = settingsModel.ApiKey;
    document.getElementById('txtChannelIdValue').value = settingsModel.ChannelId;

    websocket.onopen = function () {
        var json = { event: inRegisterEvent, uuid: inUUID };
        // register property inspector to Stream Deck
        websocket.send(JSON.stringify(json));
    };

    websocket.onmessage = function (evt) {
        // Received message from Stream Deck
        var jsonObj = JSON.parse(evt.data);
        var sdEvent = jsonObj['event'];
        switch (sdEvent) {
            case "didReceiveSettings":
                if (jsonObj.payload.settings.settingsModel.ApiKey) {
                    settingsModel.ApiKey = jsonObj.payload.settings.settingsModel.ApiKey;
                    document.getElementById('txtApiKeyValue').value = settingsModel.ApiKey;
                }
                if (jsonObj.payload.settings.settingsModel.ChannelId) {
                    settingsModel.ChannelId = jsonObj.payload.settings.settingsModel.ChannelId;
                    document.getElementById('txtChannelIdValue').value = settingsModel.ChannelId;
                }
                break;
            default:
                break;
        }
    };
}

const setSettings = (value, param) => {
    if (websocket) {
        settingsModel[param] = value;
        var json = {
            "event": "setSettings",
            "context": uuid,
            "payload": {
                "settingsModel": settingsModel
            }
        };
        websocket.send(JSON.stringify(json));
    }
};

