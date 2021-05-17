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
      return this.$store.getters.isLoggedIn
        && alreadyExistingFavouriteItem.length === 0;
    }
  },
  computed: {
    getMoviesList () {
      return this.$store.state.movies.movies;
    }
  },
  created () {
    this.$store.dispatch('getMovies');
  }
};
