const baseUrl = "https://localhost:7230/api/AbsenseApi"
Vue.createApp({
    data(){
        return{
            students: [],
            singleStudent: null,
            studentId: null,

        }
    },
    async created() {
        try{
            const response = await axios.get(baseUrl)
            this.students = await response.data
            console.log(this.students)
        }catch(ex){
                alert(ex.message)
            }
        },
        methods:{
            async getStudentById(studentId){
                const url = baseUrl + "/" + studentId
                try{
                    const response = await axios.get(url)
                    this.singlestudent = await response.data
                }catch(ex){
                alert(ex.message)
            }
        },
    }
}).mount("#app")