var baseCagesUrl = "https://localhost:5001/api/me/cages?ItemsPerPage=1&Page=";

const config = { headers: { Authorization: `Bearer ${localStorage.token}` } };

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var cages = new Vue({
    el: '#cagesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        cages: null,
        mode: null,
        currentCage: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        errors: {
            name: [],
            location: [],
        },

    },
    created: function () {
        var self = this;
        self.overViewMode = true;
        self.fetchCages(this.CurrentPage);
    },

    methods: {

        fetchCages: function () {
            var self = this;
            self.cages = null;
            self.apiErrorMessage = null;
            test.get(self.fetchUrl(), config)
                .then(function (response) {
                    self.cages = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        },
        fetchUrl: function () {
            var self = this;
            var baseUri = baseCagesUrl + self.page;
            return baseUri
        },

        ManagePagination: function (data) {
            var self = this;
            self.page = 1;
            self.hasNextPage = false;
            self.hasPreviousPage = false;
            if (data.HasPreviousPage == true) {
                self.hasPreviousPage = true;
            }
            if (data.HasNextPage == true) {
                self.hasNextPage = true;
            }
        },

        onNextPageClicked: function () {
            var self = this;
            self.page += 1;
            this.fetchCages();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            this.fetchCages();
        },

        toAddMode: function () {
            var self = this;
            this.mode = "Add new";
            self.currentCage = {
                name: "",
                location: "",

            }
            this.detailMode = false
            this.overViewMode = false;
        },

        toDetailMode: function (cage) {
            this.overViewMode = false;
            this.detailMode = true
            this.currentCage = cage;
            this.mode = "Details";
        },
        toEditMode: function () {
            this.overViewMode = false;
            this.detailMode = false
            this.mode = "Edit cage";
        },
    }
});
