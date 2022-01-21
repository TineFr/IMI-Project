
var baseUrl = "https://localhost:5001/api/me/medicines?ItemsPerPage=6&Page=";
var crudUrl = "https://localhost:5001/api/medicines/";

const config = {
    headers: { Authorization: `Bearer ${localStorage.token}`}
};


var medicines = new Vue({
    el: '#medicinesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        deleteMode: false,
        editMode: false,
        medicines: null,
        mode: null,
        currentMedicine: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        isValid: true,
        errors: {
            name: [],
            usage: [],
        },

    },
    created: function () {
        var self = this;
        self.fetchMedicines(self.page);
    },

    methods: {

        fetchMedicines: function () {
            var self = this;
            self.medicines = null;
            self.apiErrorMessage = null;
            axios.get(self.fetchBaseUrl(), config)
                .then(function (response) {
                    self.medicines = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    if (response.data.startsWith('No')) {
                        self.apiErrorMessage = "No medicines found";
                    }
                    else this.apiErrorMessage = response.data;
                })
        },
        fetchBaseUrl: function () {
            var self = this;
            var url = baseUrl + self.page;
            return url
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
            self.fetchMedicines();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            self.fetchMedicines();
        },

        toAddMode: function () {
            var self = this;
            self.resetErrors();
            self.apiErrorMessage = null;
            self.overViewMode = false;
            self.mode = "Add new";
            self.currentMedicine = {
                name: "",
                usage: "",
            }
        },

        toDetailMode: function (medicine) {
            var self = this;
            self.resetErrors();
            self.apiErrorMessage = null;
            self.overViewMode = false;
            self.detailMode = true;
            self.deleteMode = false;
            self.editMode = false;
            self.currentMedicine = medicine;
            self.mode = "Details";
        },
        toEditMode: function () {
            var self = this;
            self.editMode = true;
            self.detailMode = false;
            self.mode = "Edit medicine";
        },
        toDeleteMode: function () {
            var self = this;
            self.deleteMode = true;
            self.detailMode = false;
            self.mode = "Delete medicine";
        },

        backToList: function () {
            var self = this;
            self.fetchMedicines();
            self.overViewMode = true;
            self.detailMode = false
            self.deleteMode = false;
            self.editMode = false;
        },

        deleteMedicine: function () {
            var self = this;
            var url = crudUrl + self.currentMedicine.id;
            axios.delete(url, config)
                .then(function () {
                    self.medicines.forEach(function (medicine, i) {
                        if (medicine.id === self.currentMedicine.id) {
                            self.medicines.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })

        },
        editMedicine: function (isEditMode) {

            var self = this;
            self.validateRequest();
            if (self.isValid) {
                if (isEditMode) {
                    var url = crudUrl + self.currentMedicine.id;
                    axios.put(url, self.currentMedicine, config)
                        .then(function (response) {
                            self.toDetailMode(response.data);
                        })
                        .catch((error) => {
                            const response = error?.response;
                            self.apiErrorMessage = response.data;
                        })
                } else self.addMedicine();

            }
        },

        addMedicine: function () {
            var self = this;
            var url = crudUrl;
            axios.post(url, self.currentMedicine, config)
                .then(function () {
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })
        },

        validateRequest: function () {

            var self = this;
            self.resetErrors();

            if (!self.currentMedicine.name) {
                self.isValid = false;
                self.errors.name.push("Name is required.");
            }
            if (!self.currentMedicine.usage) {
                self.isValid = false;
                self.errors.usage.push("Usage is required.");
            }
        },

        resetErrors: function () {
            var self = this;
            self.isValid = true;
            self.errors.name = [];
            self.errors.usage = [];
        },

        cancelClicked: function () {
            var self = this
            if (self.editMode || self.deleteMode) {
                self.toDetailMode(self.currentMedicine);
            }
            else self.backToList();
        }
    }
});
