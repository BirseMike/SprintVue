import axios from 'axios';

export default class SprintService {

    getSprintItems() {
        return axios.get('/sprintitem')
            .then(res => res.data);
	}

}
