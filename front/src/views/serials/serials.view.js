
export default {
  name: 'serials-view',
  computed: {
    getSerialsList () {
      return this.$store.state.serials.serials;
    }
  },
  created () {
    this.$store.dispatch('getSerials');
  },
  methods: {
    addFavouriteClicked (item) {
      const favouriteObj = {
        contentType: 0,
        contentId: item.id
      };
      this.$store.dispatch('addFavourite', favouriteObj);
    },
    isAddToFavouriteShown (serial) {
      const alreadyExistingFavouriteItem = this.$store.state.favorites.favorites.filter((item) => {
        return item.id === serial.id && item.contentType === 0;
      });
      console.log(alreadyExistingFavouriteItem.length);
      return this.$store.getters.isLoggedIn
        && alreadyExistingFavouriteItem.length === 0;
    }
  }
};
