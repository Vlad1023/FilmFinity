import api from '@apiService';
export default {
  state: () => ({
    reviews: Object,
    PageNumber: 1,
    SortOrder: 0,
    User: JSON.parse(localStorage.getItem('user'))
  }),
  mutations: {
    initReviews (state, serverData) {
      state.reviews = serverData;
      state.PageNumber = state.reviews.pageNumber;
    },
    initSortOrder (state, data) {
      state.SortOrder = Number(data);
    },
    initPageNumber (state, serverData) {
      state.PageNumber = Number(serverData);
    },
    incrementCurrentPage (state) {
      state.PageNumber++;
    },
    decrementCurrentPage (state) {
      state.PageNumber--;
    },
    removeReview (state, reviewObj) {
      const index = state.reviews.data.indexOf(reviewObj);
      console.log(index);
      state.reviews.data.splice(index, 1);
    }
  },
  actions: {
    getReviews ({ state, commit, rootState }, pagedRequest) {
      api.post('/Reviews/Reviews',
        {
          UserId: state.User.id,
          SortOrder: pagedRequest.SortOrder ? Number(pagedRequest.SortOrder) : 0,
          PageNumber: Number(state.PageNumber),
          PageSize: pagedRequest.PageSize
        }
      )
        .then(response => { commit('initReviews', response.data); });
    },
    getReviewPage ({ state, commit, rootState }, pagedRequest) {
      api.post('/Reviews/FindReviewPage',
        {
          UserId: state.User.id,
          SortOrder: state.SortOrder,
          PageSize: pagedRequest.PageSize,
          TitleName: pagedRequest.TitleName
        }
      )
        .then(response => { commit('initPageNumber', response.data); })
        .then(() => {
          this.dispatch('getReviews', {
            PageSize: pagedRequest.PageSize,
            SortOrder: state.SortOrder
          });
        });
    },
    addReview ({ state, commit, dispatch, rootState }, reviewObj) {
      console.log(reviewObj);
      api.post('/Reviews/AddReview',
        {
          UserId: state.User.id,
          ContentType: reviewObj.contentType,
          FilmId: reviewObj.contentId,
          DirectingRating: reviewObj.directingRate,
          PlotRating: reviewObj.plotRate,
          EntertainmentRating: reviewObj.entertainmentRate,
          ActorsRating: reviewObj.actorsRate,
          ReviewTitle: reviewObj.reviewHeader,
          ReviewContent: reviewObj.reviewText
        }
      ).then(response => {
        dispatch('getUserInfo');
      });
    },
    deleteReview ({ state, commit, dispatch, rootState }, reviewId) {
      api.delete('/Reviews/DeleteReview', { params: { reviewId: reviewId } })
        .then(response => {
          dispatch('getUserInfo');
        });
    }
  }
};
