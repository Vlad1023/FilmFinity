import { FfReviewsBlocks, FfReviewsRows } from '@components/reviews';
export default {
  data: function () {
    return {
      isRowView: true,
      sortValue: this.$t('favorite.value6'),
      inputString: null
    };
  },
  components: {
    FfReviewsBlocks, FfReviewsRows
  },
  computed: {
    getReviewsList () {
      return this.$store.state.reviews.reviews.data;
    },
    getTotalElements () {
      return this.$store.state.reviews.reviews.totalCount;
    },
    getPageSize () {
      return this.$store.state.reviews.reviews.pageSize;
    },
    getCurrentPageNumber () {
      return Number(this.$store.state.reviews.PageNumber);
    },
    options () {
      return [
        {
          value: '0',
          label: this.$t('reviews.value0')
        },
        {
          value: '1',
          label: this.$t('reviews.value1')
        },
        {
          value: '2',
          label: this.$t('reviews.value2')
        },
        {
          value: '3',
          label: this.$t('reviews.value3')
        },
        {
          value: '4',
          label: this.$t('reviews.value4')
        },
        {
          value: '5',
          label: this.$t('reviews.value5')
        }
      ];
    }
  },
  beforeCreate () {
    this.$store.dispatch('getReviews', { PageSize: 2 });
  },
  methods: {
    onClick () {
      this.isRowView = !this.isRowView;
    },
    nextPageClick () {
      this.$store.commit('incrementCurrentPage');
      this.$refs.reviews.pageChanged();
    },
    previousPageClicked () {
      this.$store.commit('decrementCurrentPage');
      this.$refs.reviews.pageChanged();
    },
    sortContent (value) {
      this.$refs.reviews.sortContent(value);
    },
    findReviewPage () {
      this.$refs.reviews.FindReviewPage(this.inputString);
    }
  },
  name: 'ff-review'
};
