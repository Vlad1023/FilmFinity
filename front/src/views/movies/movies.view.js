export default {
  name: 'ff-movies',
  filters: {
    withoutFirstElement (titles) {
      return Array.isArray(titles) && titles.length ? titles.slice(1, -1) : [];
    }
  },
  methods: {
    getImgSrc (imgPath) {
      return `${this.$store.state.baseUrl}/${imgPath}`;
    },
    addFavouriteClicked (item) {
      const favouriteObj = {
        contentType: 1,
        contentId: item.id
      };
      this.$store.dispatch('addFavourite', favouriteObj);
    },
    isAddToFavouriteShown (movie) {
      const alreadyExistingFavouriteItem = this.$store.state.favorites.favorites.filter((item) => {
        return item.id === movie.id && item.contentType === 1;
      });
      console.log(alreadyExistingFavouriteItem);
      return alreadyExistingFavouriteItem.length === 0;
    },
    removeFavouriteClicked (movie) {
      this.$store.dispatch('deleteFavouriteMovie', movie.id);
    }
  },
  computed: {
    getMoviesList () {
      return this.$store.state.movies.movies;
    },
    isLoggedIn () {
      return this.$store.getters.isLoggedIn;
    }
  },
  created () {
    this.$store.dispatch('getMovies');
    this.$store.dispatch('getFavorites', {
      currentPage: 0,
      sortState: 0,
      isPageRequestNeeded: false
    }, false);
  }
};
