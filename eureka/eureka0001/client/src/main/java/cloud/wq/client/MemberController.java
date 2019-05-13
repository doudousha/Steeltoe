package cloud.wq.client;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MemberController {



    @RequestMapping("/getMember")
    public String getMember(){
        return "this is a  member service:会员服务";
    }
}
