import api from '@apiService';
export default {
  state: {
    movies: [],
    User: JSON.parse(localStorage.getItem('user'))
  },
  mutations: {
    initMovies (state, serverData) {
      state.movies = serverData;
    }
  },
  actions: {
    getMovies ({ state, commit, rootState }) {
      api
        .get('/Movies')
        .then(response => { commit('initMovies', response.data); });
    }
  }
};
