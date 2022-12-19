const baseUrl = "https://absenseapi20221214143540.azurewebsites.net/api/absenseapi"
Vue.createApp({
    data(){
        return{
            students: [],
            singleStudent: null,
            name: null,
            idToBeDeleted: null,
            idToUpdate: null,
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
                const url = baseUrl + "/?name=" + name   
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
        async deleteById(idToBeDeleted){
            const url = baseUrl + "/" + idToBeDeleted
            try {
                console.log(url)
                response = await axios.delete(url)
                this.getAll()
            } catch (ex){
                alert(ex.message)
            }
        },
        async updateRecord() {
            console.log("hejsa")
            const url = baseUrl + "/" + this.idToUpdate
            try{
                response = await axios.put(url, this.recordToUpdate)
                this.getAll()
            } catch(ex) {
                alert(ex.message)
            }
        }
    }
}).mount("#app")