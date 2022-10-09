import { Autocomplete, CircularProgress, TextField } from '@mui/material';
import { useEffect, useState } from 'react';
import PostCodeService from '../Services/postcode-service';
import PostCodeDetail from './PostCodeDetail';
import '../CSS/PostCode.css'

function PostCode(){
    const [open, setOpen] = useState(false);
    const [options, setOptions] = useState([]);
    const [postCode, setPostCode] = useState('');
    const loading = open && options.length === 0;
  
    const onChangeHandler = async (value: any) => {
      const response = await PostCodeService.GetPostCodes(value);
      if(response.data) {
        setOptions(response.data);
      }
      else{
        setOptions([]);
      }
    };
  
    useEffect(() => {
      if (!open) {
        setOptions([]);
      }
    }, [open]);
  
    const onInputChange = (event: any, value: any, reason: any) => {
      if (value.length >= 6) {
        setPostCode(value);
      } else {
        setPostCode('');
      }
    };
    return (
        <div className="post-code-container">
            <Autocomplete
              id="postcode-autocomplete"
              style={{ width: 300 }}
              open={open}
              onOpen={() => {
                setOpen(true);
              }}
              onClose={() => {
                setOpen(false);
              }}
              isOptionEqualToValue={(option: any, value: any) => option === value}
              getOptionLabel={(option: any) => option}
              onInputChange={onInputChange}
              options={options}
              loading={loading}
              renderInput={(params: any) => (
                <TextField
                  {...params}
                  label="Please Enter post code"
                  variant="outlined"
                  onChange={ev => {
                    if (ev.target.value) {
                        onChangeHandler(ev.target.value);
                    }
                  }}
                  InputProps={{
                    ...params.InputProps,
                    endAdornment: (
                      <>
                        {loading ? (
                          <CircularProgress color="inherit" size={20} />
                        ) : null}
                        {params.InputProps.endAdornment}
                      </>
                    )
                  }}
                />
              )}
            />
           {postCode ? <PostCodeDetail postCode={postCode} /> : <span className='no-msg'>No Post Code Selected</span>} 
        </div>
      );
}

export default PostCode;