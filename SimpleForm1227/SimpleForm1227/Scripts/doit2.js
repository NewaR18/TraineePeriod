function AppViewModel() {
    var self = this;

    models = {
        Master: function (item) {
            item = item || {};
            this.on1 = ko.observable(item.on1 || '');
            this.on2 = ko.observable(item.on2 || '');
            this.on3 = ko.observable(item.on3 || '');
            this.on4 = ko.observable(item.on4 || '');
            this.hello = ko.observable(item.hello || '');
            this.availables = ko.observableArray([{ name: 'Nepali', id: 1 },
            { name: 'Chinese', id: 2 },
            { name: 'Indians', id: 3 },
            { name: 'Portuguese', id: 4 },
            { name: 'Argentinan', id: 5 }]);
        }
    }
    clearthis = function () {
        self.Master().on1("");
        self.Master().on2("");
        self.Master().on3("");
        self.Master().on4("");
    }
    saveprocess = function () {
        alert('rip');
        if (self.Master().on1() == '' || self.Master().on1() == undefined) {
            alert('Please fill Name2');
        } else if (self.Master().on2() == '' || self.Master().on2() == undefined) {
            alert('Please fill email');
        } else if (self.Master().on3() == '' || self.Master().on3() == undefined) {
            alert('Please fill Address');
        } else if (self.Master().on4() == '' || self.Master().on4() == undefined) {
            alert("Please fill Phone Number");
        } else if (self.Master().hello() == undefined) {
            alert("Please select your Nationality");
        } else {
            document.write("Submitted");
        }
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
/*function myFunction() {
    document.getElementById("demo").innerHTML = "Paragraph changed.";
}*/