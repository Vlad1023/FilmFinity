export default {
  props: {
    reviews: Array
  },
  methods: {
    getAverageFromArray (floats) {
      return floats.reduce((a, b) => a + b) / floats.length;
    },
    pageChanged () {
      this.$store.dispatch('getReviews', {
        PageSize: 2
      });
    },
    sortContent (value) {
      this.$store.commit('initSortOrder', value);
      this.$store.dispatch('getReviews', {
        PageSize: 2,
        SortOrder: value
      });
    },
    FindReviewPage (substring) {
      this.$store.dispatch('getReviewPage', {
        PageSize: 2,
        TitleName: substring
      });
    },
    DeleteIconClicked (item) {
      const self = this;
      this.$swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      }).then(function (res) {
        if (res.isConfirmed) {
          self.$store.dispatch('deleteReview', item.id);
          self.$store.commit('removeReview', item);
        }
      });
    }
  },
  name: 'ff-review'
};
