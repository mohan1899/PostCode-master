import React, { useEffect, useState } from 'react';
import { postCodeModel } from '../Model/PostCodeModel';
import PostCodeService from '../Services/postcode-service';

function PostCodeDetail(props: any){
  const [postCodeDetail, setPostCodeDetail] = useState(postCodeModel);
  useEffect(() => {
    if (props.postCode.length > 5) {
      //This function returns PostCodeDetail by the postcode parameter, parameter length should be at least 6 character
      const getPostCodeDetail = async () => {
        const response = await PostCodeService.GetPostCodeDetail(props.postCode);
        setPostCodeDetail(response.data);
    };

    getPostCodeDetail();
    }
  }, [props]);
   
    return (
        <React.Fragment>
          <h3> Post Code Details</h3>
          <table>
            <tr><td>Country :</td><td>{postCodeDetail.country}</td></tr>
            <tr><td>Region :</td><td>{postCodeDetail.postcode}</td></tr>
            <tr><td>Admin District :</td><td>{postCodeDetail.region}</td></tr>
            <tr><td>Parliamentary Constituency :</td><td>{postCodeDetail.adminDistrict}</td></tr>
            <tr><td>Area :</td><td>{postCodeDetail.area}</td></tr>
          </table>
        </React.Fragment>
      );
}

export default PostCodeDetail;