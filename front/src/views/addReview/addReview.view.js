export default {
  beforeCreate () {
    this.$store.dispatch('getMovies', {});
    this.$store.dispatch('getSerials', {});
  },
  data: function () {
    return {
      value: null,
      directingRate: 1,
      plotRate: 1,
      entertainmentRate: 1,
      actorsRate: 1,
      reviewHeader: '',
      reviewText: ''
    };
  },
  computed: {
    getShowsOptions () {
      const movies = this.$store.state.movies.movies,
            tvShows = this.$store.state.serials.serials,
            moviesMapped = movies.map(function (movieObj) {
              return {
                contentId: movieObj.id,
                label: movieObj.title,
                imageSource: movieObj.imageSource,
                contentType: 1
              };
            }),
            serialsMapped = tvShows.map(function (serialObj) {
              return {
                contentId: serialObj.id,
                label: serialObj.name,
                imageSource: serialObj.posterImageSource,
                contentType: 0
              };
            });
      return moviesMapped.concat(serialsMapped);
    },
    isSendDisabled () {
      return !this.value || !this.reviewHeader || !this.reviewText
      || this.showMinHeaderLengthError || this.showMinTextLengthError;
    },
    generalRate () {
      return (this.directingRate + this.plotRate + this.entertainmentRate + this.actorsRate) / 4;
    },
    showMinHeaderLengthError () {
      return !this.reviewHeader || this.reviewHeader.length < 15;
    },
    showMinTextLengthError () {
      return !this.reviewText || this.reviewText.length < 15;
    }
  },
  methods: {
    cancelReview () {
      this.value = null;
      this.directingRate = 1;
      this.plotRate = 1;
      this.entertainmentRate = 1;
      this.actorsRate = 1;
      this.reviewHeader = '';
      this.reviewText = '';
    },
    sendReview () {
      const review = {
        contentType: this.value.contentType,
        contentId: this.value.contentId,
        directingRate: this.directingRate,
        plotRate: this.plotRate,
        entertainmentRate: this.entertainmentRate,
        actorsRate: this.actorsRate,
        reviewHeader: this.reviewHeader,
        reviewText: this.reviewText
      };
      this.$store.dispatch('addReview', review);
      this.$store.dispatch('getUserInfo');
      this.cancelReview();
    }
  },
  name: 'ff-addreview'
};
