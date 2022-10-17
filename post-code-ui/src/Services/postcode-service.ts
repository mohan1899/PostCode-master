import http from "../BaseService/base-service";

class PostCodeService {
    //Return postcodes
    GetPostCodes(postCode: string) {
        return http.get(`/GetPostCodes?postCode=${postCode}`);
    }
    //Return postcode detail
    GetPostCodeDetail(postCode: string) {
        return http.get(`/GetPostCodeDetail?postCode=${postCode}`);
    }
}

export default new PostCodeService();