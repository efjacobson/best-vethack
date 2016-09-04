vetchat.services.profile = vetchat.services.profile || {};

vetchat.services.profile.create = function ( data, onSuccess, onError) {
    var payload = data;
    var url = "/api/buddy/create"
    var settings = {
        cache: false
	, contentType: "application/x-www-form-urlencoded; charset=UTF-8"
	, data: payload
	, dataType: "json"
	, success: onSuccess
	, error: onError
	, type: "POST"
    };

    $.ajax(url, settings);

}