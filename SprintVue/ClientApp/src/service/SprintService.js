import axios from 'axios';

export default class SprintService {

    getSprints() {
        return axios.get('/sprint')
            .then(res => res.data);
	}

    getSprintItems(sprintId) {
        return axios.get('/sprintitem?sprintId='+sprintId)
            .then(res => res.data);
    }

    getSprintReport(sprintId) {
        return axios.get('/sprintReport?sprintId=' + sprintId)
            .then(res => res.data);
    }

    getSprintBurnUp(sprintId) {
        return axios.get('/sprintBurnUp?sprintId=' + sprintId)
            .then(res => res.data);
    }
}
