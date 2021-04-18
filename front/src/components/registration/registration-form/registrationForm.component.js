import FfAuthorization from '@/components/authorization/authorization.component.vue';

export default {
  data () {
    return {
      name: '',
      email: '',
      password: '',
      isVisibleErrors: {
        name: false,
        email: false,
        emailRegistered: false,
        password: false
      }
    };
  },
  components: {
    FfAuthorization
  },
  methods: {
    changeRegisterVisible () {
      this.$store.dispatch('ChangeRegisterVisible');
      this.$store.dispatch('ChangeLoginVisible');
    },
    registration () {
      this.isVisibleErrors.name = this.isVisibleErrors.email
      = this.isVisibleErrors.password = false;
      this.$store.dispatch('AddUser', {
        userName: this.name,
        email: this.email,
        userPassword: this.password
      })
        .then(result => {
          this.$emit('complete');
          this.email = this.userName = this.password = '';
        })
        .catch(error => {
          try {
            this.isVisibleErrors.emailRegistered = error.data.Email[0];
          } catch {
            this.isVisibleErrors.name = error.data.errors.UserName[0];
            this.isVisibleErrors.email = error.data.errors.Email[0];
            this.isVisibleErrors.password = error.data.errors.UserPassword[0];
          }
        });
    }
  }
};
