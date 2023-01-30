function AppViewModel() {
    var self = this;
    models = {
        Master: function (item) {
            item = item || {};
            this.name = ko.observable(item.name || '');
            this.email = ko.observable(item.email || '');
            this.subject = ko.observable(item.subject || '');
            this.message = ko.observable(item.message || '');
        }
    }
    savethis = function () {
        $.ajax({
            type: "POST",
            url: "WebForm1.aspx/QuickMessage",
            dataType: "json",
            data: { name: self.Master().name(), email: self.Master().email(), subject: self.Master().subject(), message: self.Master().message() },
            success: function (result) {
                console.log(result);
            },
            error: function (req, status, error) {
                console.log(status);
                console.log(req);
                console.log(error);
            }
        });
    }
    clearall = function () {
        self.Master().name("");
        self.Master().email("");
        self.Master().subject("");
        self.Master().message("");
    }
    Init = function () {
        self.Master = ko.observable(new models.Master());
    }
    Init();

}
var obj;
$(document).ready(function () {
    obj = new AppViewModel();
    ko.applyBindings(obj);
});