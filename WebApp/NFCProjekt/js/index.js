const baseUrl = "https://localhost:7230/api/AbsenseApi"
Vue.createApp({
    data(){
        return{
            students: [],
            singleStudent: null,
            name: null,
            nFCId: null

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
            async getAll(name){
                const url = baseUrl + "/" + name   
                try{
                    const response = await axios.get(url)
                    this.students = await response.data
                }catch(ex){
                alert(ex.message)
            }
        },
            async addStudent(){
                try{
                    response = await axios.post(baseUrl, this.addStudent)
                    this.getAll()   
                }catch(ex){
                alert(ex.message)
            }
        },
    }
}).mount("#app")