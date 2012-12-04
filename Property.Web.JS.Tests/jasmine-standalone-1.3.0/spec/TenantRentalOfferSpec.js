//Move to helper
beforeEach(function () {
    this.addMatchers({
        toHaveAddress: function (expectedAddress) {
            var address = this.actual.Address;
            return address.Line1 === expectedAddress.Line1 &&
                   address.Line2 === expectedAddress.Line2;
        }
    });
});

describe("PropertyListing", function() {
    var propertyListing;
    it("should have sensible defaults", function () {
        propertyListing = new PropertyListing();
        expect(propertyListing.get("Term")).toEqual("24Months");
        expect(propertyListing.get("BreakTerm")).toEqual("12Months");
        expect(propertyListing.get("PaymentFrequency")).toEqual("Monthly");
    });
    
});

describe("TenantRentalOffer", function () {
    var offer;
    var propertyListing;
    var user;

    beforeEach(function () {
        offer = new TenantRentalOffer();
        propertyListing = new PropertyListing();
        user = new Tenant();
    });

    it("should be able to preload PropertyListing Address", function () {
        offer.fromProperty(propertyListing);
        expect(offer).toHaveAddress(propertyListing.Address);
    });
    
    it("should be able to preload PropertyListing Offer Default", function () {
        offer.fromProperty(propertyListing);
        expect(offer.get("Term")).toBeDefined();
        expect(offer.get("Term")).toEqual(propertyListing.get("Term"));
        expect(offer.get("BreakTerm")).toBeDefined();
        expect(offer.get("BreakTerm")).toEqual(propertyListing.get("BreakTerm"));     
        expect(offer.get("ProposedPaymentFrequency")).toBeDefined();
        expect(offer.get("ProposedPaymentFrequency")).toEqual(propertyListing.get("PaymentFrequency"));

        expect(offer.get("ProposedRent")).toEqual(propertyListing.get("Rent"));
        expect(offer.get("Deposit")).toEqual(propertyListing.get("Deposit"));
    });

    it("should be able to set Offer Defaults by PropertyListing", function () {
        var propDefault = {
            "Term": "24Months",
            "BreakTerm": "12Months",
            "PaymentFrequency": "Monthly"
        };
        offer = new TenantRentalOffer(propDefault);
        expect(offer.get("Term")).toBeDefined();
        expect(offer.get("Term")).toEqual(propDefault.Term);
        expect(offer.get("BreakTerm")).toBeDefined();
        expect(offer.get("BreakTerm")).toEqual(propDefault.BreakTerm);
        expect(offer.get("ProposedPaymentFrequency")).toBeDefined();
        expect(offer.get("ProposedPaymentFrequency")).toEqual(propDefault.PaymentFrequency);
    });

    //describe("when song has been paused", function () {
    //    beforeEach(function () {
    //        player.play(song);
    //        player.pause();
    //    });

    //    it("should indicate that the song is currently paused", function () {
    //        expect(player.isPlaying).toBeFalsy();

    //        // demonstrates use of 'not' with a custom matcher
    //        expect(player).not.toBePlaying(song);
    //    });

    //    it("should be possible to resume", function () {
    //        player.resume();
    //        expect(player.isPlaying).toBeTruthy();
    //        expect(player.currentlyPlayingSong).toEqual(song);
    //    });
    //});

    //// demonstrates use of spies to intercept and test method calls
    //it("tells the current song if the user has made it a favorite", function () {
    //    spyOn(song, 'persistFavoriteStatus');

    //    player.play(song);
    //    player.makeFavorite();

    //    expect(song.persistFavoriteStatus).toHaveBeenCalledWith(true);
    //});

    ////demonstrates use of expected exceptions
    //describe("#resume", function () {
    //    it("should throw an exception if song is already playing", function () {
    //        player.play(song);

    //        expect(function () {
    //            player.resume();
    //        }).toThrow("song is already playing");
    //    });
    //});
});


