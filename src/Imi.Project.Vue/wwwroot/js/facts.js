var baseUrl = "https://some-random-api.ml/animal/birb";


var birds = new Vue({
    el: '.factContainer',
    data: {
        facts: [],
        currentIndex: 0,
        currentFact: null,
    },
    created: function () {
        var self = this;
        self.fetchNewFact();
    },
    computed: {
        getCount: function () {
            var self = this;
            return self.facts.length;
        },

        hasPreviousFact: function () {
            var self = this;
            return self.currentIndex > 0;
        }
    },
    methods: {
        fetchNewFact: function () {
            var self = this;;
            axios.get(baseUrl)
                .then(function (response) {
                    self.facts.push(response.data);
                    self.currentIndex = self.getCount - 1;
                })
                .then(function (){
                    self.showFact();
                })
        },
        showFact: function () {
            var self = this;
            self.currentFact = self.facts[self.currentIndex];
        },
        getNextFact() {
            var self = this
            if (self.currentIndex == (self.getCount - 1)) {
                self.fetchNewFact();
            }
            else {
                self.currentIndex += 1;
                self.showFact();
            }
        },
        getPreviousFact() {
            var self = this
            self.currentIndex -= 1;
            self.showFact();
        }        
    }
});
