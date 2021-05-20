import api from '@apiService';
export default {
  state: () => ({
    favorites: [],
    totalCount: null,
    pageSize: null,
    User: JSON.parse(localStorage.getItem('user'))
  }),
  getters: {},
  mutations: {
    updateFavorites (state, favorites) {
      state.favorites = favorites;
    },
    updateTotalCount (state, totalCount) {
      state.totalCount = totalCount;
    },
    updatePageSize (state, pageSize) {
      state.pageSize = pageSize;
    }
  },
  actions: {
    async getFavorites ({ state, commit, rootState }, request) {
      if (request.isPageRequestNeeded) {
        await api
          .get(`/Favorite/${state.User.id}/${request.currentPage}/${request.sortState}
          /${true}`)
          .then(response => {
            commit('updateFavorites', response.data.data);
            commit('updateTotalCount', response.data.totalCount);
            commit('updatePageSize', response.data.pageSize);
          });
      } else {
        await api
          .get(`/Favorite/${state.User.id}/${0}/${1}
          /${false}`)
          .then(response => {
            commit('updateFavorites', response.data.data);
          });
      }
    },
    addFavourite ({ state, dispatch, commit, rootState }, favouriteObj) {
      console.log(favouriteObj);
      api.post('/Favorite/AddFavourite',
        {
          UserId: state.User.id,
          ContentType: favouriteObj.contentType,
          ContentId: favouriteObj.contentId
        })
        .then(response => {
          dispatch('getFavorites', {
            currentPage: 0,
            sortState: 0,
            isPageRequestNeeded: false
          }, false);
          dispatch('getUserInfo');
        });
    },
    deleteFavouriteMovie ({ state, dispatch, commit, rootState }, movieId) {
      api.delete('/Favorite/DeleteFavouriteMovie', { params: { movieId: movieId } })
        .then(response => {
          dispatch('getFavorites', {
            currentPage: 0,
            sortState: 0,
            isPageRequestNeeded: false
          }, false);
          dispatch('getUserInfo');
        });
    },
    deleteFavouriteSerial ({ state, dispatch, commit, rootState }, serialId) {
      api.delete('/Favorite/DeleteFavouriteSerial', { params: { serialId: serialId } })
        .then(response => {
          dispatch('getFavorites', {
            currentPage: 0,
            sortState: 0,
            isPageRequestNeeded: false
          }, false);
          dispatch('getUserInfo');
        });
    }
  }
};
