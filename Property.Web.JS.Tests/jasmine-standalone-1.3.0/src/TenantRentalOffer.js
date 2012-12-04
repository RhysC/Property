(function ($) {

    window.Address = Backbone.Model.extend({
        defaults: {
            "FlatNumber": "",
            "PropertyName": "",
            "PropertyNumber": "",
            "StreetName": "",
            "County": "",
            "Postcode": "",
        },
        validate: function (attr) {
            console.log("attr=" + attr);
            window.abc123att = attr;
            var errors = new Array();
            if (!attr.Postcode) {
                console.log("postcode not valid");
                errors["Postcode"] = "must have a post code";
                console.log("errors[Postcode" + errors["Postcode"])
            }
            window.eee = errors;
            if (errors.length > 0) {
                console.log("returning errors");
                return errors;
            }
           
            console.log("no errors");
        }
        /*
        Flat number / property name
        Property number 
        Street name
        County
        Postcode - http://stackoverflow.com/questions/164979/uk-postcode-regex-comprehensive
        */
    });

    window.PropertyListing = Backbone.Model.extend({
        defaults: {
            "Term": "24Months",
            "BreakTerm": "12Months",
            "PaymentFrequency": "Monthly"
        }
    });

    window.Tenant = Backbone.Model.extend({});

    window.TenantRentalOffer = Backbone.Model.extend({
        initialize: function (attr) {
            if (!attr) return;
            if ("Rent" in attr) {
                this.set({ ProposedRent: attr.Rent });
            }
            if ("PaymentFrequency" in attr) {
                this.set({ ProposedPaymentFrequency: attr.PaymentFrequency });
            }
        },
        fromProperty: function (propertyListing) {
            this.set({ Term: propertyListing.get("Term") });
            this.set({ BreakTerm: propertyListing.get("BreakTerm") });
            this.set({ Deposit: propertyListing.get("Deposit") });
            this.set({ ProposedRent: propertyListing.get("Rent") });
            this.set({ ProposedPaymentFrequency: propertyListing.get("PaymentFrequency") });
        }
    });
})(jQuery);