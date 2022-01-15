var baseCagesUrl = "https://localhost:5001/api/me/cages?ItemsPerPage=6&Page=";
var crudUrl = "https://localhost:5001/api/cages/";

const config = {
    headers: {
        Authorization: `Bearer ${localStorage.token}`,
       'Content-Type': 'multipart/form-data'
    }
};

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var cages = new Vue({
    el: '#cagesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        deleteMode: false,
        editMode : false,
        cages: null,
        mode: null,
        cageRequest: null,
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
            test.get(self.fetchBaseUrl(), config)
                .then(function (response) {
                    self.cages = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        },
        fetchBaseUrl: function () {
            var self = this;
            var baseUri = baseCagesUrl + self.page;
            return baseUri
        },

        ManagePagination: function (data) {
            var self = this;
            self.page = data.CurrentPage;
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
            this.detailMode = true;
            this.deleteMode = false;
            this.editMode = false;
            this.currentCage = cage;
            this.mode = "Details";
        },
        toEditMode: function () {
            this.editMode = true;
            this.detailMode = false;
            this.mode = "Edit cage";
        },
        toDeleteMode: function () {
            this.deleteMode = true;
            this.detailMode = false;
            this.mode = "Delete cage";
        },

        backToList: function () {
            if (this.cages == null) {

                this.apiErrorMessage = "No cages found";
            }
            this.overViewMode = true;
            this.detailMode = false
            this.deleteMode = false;
            this.editMode = false;
        },

        deleteCage: function () {
            var self = this;
            var url = crudUrl + self.currentCage.id;
            axios.delete(url, config)
                .then(function (response) {
                    self.cages.forEach(function (cage, i) {
                        if (cage.id === self.currentCage.id) {
                            self.cages.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
            
        },
        editCage: function (isEditMode) {

            var self = this;
            const formData = new FormData();
            formData.append("Name", self.currentCage.name);
            formData.append("Location", self.currentCage.location);

            if (isEditMode) {
                var url = crudUrl + self.currentCage.id;
                axios.put(url, formData, config)
                    .then(function (response) {
                        self.toDetailMode(response.data);
                    })
                    .catch((error) => {
                        const response = error?.response;
                        self.apiErrorMessage = response.data;
                    })
            } else this.addCage(formData);
        },

        addCage: function (data) {
            var self = this;
            var url = crudUrl;
            axios.post(url, data, config)
                .then(function (response) {
                    self.cages.push(response.data);
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })
        },
    }
});
