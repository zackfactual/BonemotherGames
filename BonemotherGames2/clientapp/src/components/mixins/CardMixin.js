export default {
    methods: {
        buildDataRetrievalUrl (retrievalUrl) {
            if (this.$route.params.follower_id != null) {
                retrievalUrl = retrievalUrl.concat(`/${this.$route.params.follower_id}`)
                if (this.$route.query.ancestry != null) {
                    retrievalUrl = retrievalUrl.concat(`/${this.$route.query.ancestry}`)
                    if (this.$route.query.subancestry != null) {
                        retrievalUrl = retrievalUrl.concat(`/${this.$route.query.subancestry}`)
                    }
                }
            }
            return retrievalUrl
        }
    }
}
