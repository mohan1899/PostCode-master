import http from "../BaseService/base-service";

class PostCodeService {
    GetPostCodes(postCode: string) {
        return http.get(`/GetPostCodes?postCode=${postCode}`);
    }
    GetPostCodeDetail(postCode: string) {
        return http.get(`/GetPostCodeDetail?postCode=${postCode}`);
    }
}

export default new PostCodeService();