
VAR actor1 = "Player"
VAR actor2 = "Linh"
VAR actor3 = "Minh"

VAR courage = 10
VAR trustLinh = 0
VAR trustMinh = 0
VAR evidence = 0

-> chapter1

=== chapter1 ===

# hideall
Người kể: <i>Thứ Hai, 7 giờ 15 phút sáng.</i>

Người kể: Một buổi sáng tưởng chừng bình thường tại lớp 11A3.

Người kể: Nhưng ngay khi bước qua cửa lớp, bạn nhận ra có điều gì đó không ổn.

Người kể: Những cuộc trò chuyện đột ngột im bặt.

Người kể: Trên màn hình điện thoại của vài học sinh là hình ảnh một đoạn tin nhắn riêng tư.

# show:actor2:left:angry
Người kể: Linh bước đến trước mặt bạn, đôi mắt đỏ hoe.

{actor2}: <color=red><b>Cuối cùng cậu cũng đến!</b></color>

{actor1}: Linh? Có chuyện gì vậy?

{actor2}: Cậu còn hỏi được sao?

{actor2}: Chuyện gia đình mình... chuyện mà mình chỉ kể riêng cho cậu...

{actor2}: <b>Tại sao cả lớp đều biết?!</b>

Người kể: Linh đưa điện thoại ra trước mặt bạn.

Người kể: Trên màn hình là ảnh chụp một cuộc trò chuyện, với những dòng tin nhắn quen thuộc.

{actor1}: Khoan đã. Mình không hề gửi nó cho ai!

{actor2}: Vậy cậu giải thích thế nào về những bức ảnh này?

Người kể: Cả lớp bắt đầu xì xào.

+ [Bình tĩnh giải thích với Linh.]
    ~ trustLinh += 2
    ~ courage += 1
    -> calm_response

+ [Tức giận vì bị nghi oan.]
    ~ trustLinh -= 2
    ~ courage += 2
    -> angry_response

+ [Im lặng và quan sát những bức ảnh.]
    ~ evidence += 1
    -> silent_response


=== calm_response ===

{actor1}: Linh, mình hiểu tại sao cậu tức giận.

{actor1}: Nhưng mình hứa, mình chưa từng gửi những tin nhắn đó.

# show:actor2:left:sad
{actor2}: Mình đã rất tin tưởng cậu...

{actor2}: Mình thực sự không biết nên tin ai nữa.

Người kể: Linh cúi đầu, bàn tay nắm chặt chiếc điện thoại.

-> minh_arrives


=== angry_response ===

{actor1}: <color=red><b>Đủ rồi!</b></color>

{actor1}: Cậu không có bằng chứng mà đã kết luận mình làm chuyện đó?

# show:actor2:left:angry
{actor2}: Vậy tại sao chỉ có cậu biết?!

{actor1}: Mình cũng đang muốn biết đây!

Người kể: Không khí giữa hai người càng trở nên căng thẳng.

-> minh_arrives


=== silent_response ===

Người kể: Bạn không trả lời ngay.

Người kể: Thay vào đó, bạn nhìn kỹ ảnh chụp tin nhắn.

Người kể: Có gì đó không đúng.

Người kể: <color=yellow>Thời gian hiển thị trong ảnh chụp dường như bị lệch.</color>

{actor2}: Sao cậu không nói gì?

{actor1}: Mình chỉ đang suy nghĩ.

{actor2}: ...

-> minh_arrives


=== minh_arrives ===

# show:actor3:right:normal
Người kể: Đúng lúc đó, Minh bước vào lớp.

{actor3}: Có chuyện gì mà ồn ào vậy?

# show:actor2:left:angry
{actor2}: Minh, chuyện này không liên quan đến cậu!

{actor3}: Khoan đã, mình vừa nghe mấy người ngoài hành lang nói về ảnh chụp tin nhắn.

{actor3}: Cậu cũng nhìn thấy rồi đúng không, Player?

{actor1}: Ừ.

{actor3}: Mình nghĩ chuyện này có gì đó bất thường.

{actor2}: Bất thường?

{actor3}: Những bức ảnh xuất hiện trong nhóm lớp lúc 6 giờ 30.

{actor3}: Nhưng lúc đó mình thấy một tài khoản lạ vừa tham gia nhóm.

# show:actor2:left:normal
{actor2}: Tài khoản lạ?

{actor3}: Ừ. Tên hiển thị chỉ có một dấu chấm.

Người kể: Linh im lặng một lúc.

{actor2}: Vậy... ý cậu là có người cố tình làm chuyện này?

{actor3}: Mình chưa chắc. Nhưng có thể chúng ta đang bỏ sót điều gì đó.

-> investigation_choice


=== investigation_choice ===

Người kể: Bạn cần quyết định sẽ làm gì tiếp theo.

+ [Nhờ Minh giúp kiểm tra tài khoản lạ.]
    ~ trustMinh += 2
    ~ evidence += 1
    -> investigate_account

+ [Ở lại nói chuyện riêng với Linh.]
    ~ trustLinh += 2
    -> talk_with_linh

+ [Tự mình tìm bằng chứng.]
    ~ courage += 2
    -> investigate_alone


=== investigate_account ===

{actor1}: Minh, cậu giúp mình kiểm tra tài khoản đó được không?

# show:actor3:right:happy
{actor3}: Được. Mình cũng đang định đề nghị.

{actor3}: Có thể hỏi lớp trưởng xem ai đã thêm tài khoản ấy.

# show:actor2:left:sad
{actor2}: Nếu thực sự có người cố tình...

{actor2}: Mình đã trách nhầm cậu sao?

{actor1}: Chúng ta chưa biết sự thật mà.

-> after_investigation


=== talk_with_linh ===

{actor1}: Linh, mình muốn nói chuyện riêng với cậu.

# show:actor3:right:normal
{actor3}: Vậy mình ra ngoài trước. Có gì cứ gọi nhé.

# hide:actor3

# show:actor2:left:sad
{actor2}: Cậu muốn nói gì?

{actor1}: Mình không muốn chuyện này phá hỏng tình bạn của chúng ta.

{actor2}: ...

{actor2}: Xin lỗi. Mình đã mất bình tĩnh.

{actor1}: Mình hiểu.

Người kể: Ánh mắt Linh dịu lại, dù nỗi lo vẫn chưa biến mất.

-> after_investigation


=== investigate_alone ===

{actor1}: Mình muốn tự kiểm tra lại mọi chuyện.

# show:actor3:right:normal
{actor3}: Đừng làm gì liều lĩnh nhé.

{actor1}: Yên tâm.

# hide:actor3

Người kể: Bạn mở điện thoại, kiểm tra những ảnh chụp được chia sẻ.

Người kể: Một chi tiết khiến bạn chú ý.

Người kể: <color=yellow>Tên người gửi trong một bức ảnh có kiểu chữ khác những ảnh còn lại.</color>

~ evidence += 1

{actor1}: Có thể những bức ảnh đã bị chỉnh sửa...

-> after_investigation


=== after_investigation ===

Người kể: <i>Tiếng chuông vào lớp vang lên.</i>

# hideall

Người kể: Mọi người trở về chỗ ngồi, nhưng bầu không khí nặng nề vẫn còn đó.

Người kể: Bạn nhận được một tin nhắn từ số điện thoại lạ.

Người kể: <color=yellow><b>"Đừng tìm hiểu chuyện này nữa."</b></color>

Người kể: Chưa đầy một giây sau, một tin nhắn thứ hai xuất hiện.

Người kể: <color=red><b>"Nếu không, bí mật tiếp theo sẽ là của cậu."</b></color>

{actor1}: ...?!

Người kể: Bạn nhìn quanh lớp.

Người kể: Có ai đó đang nhìn mình.

Người kể: Nhưng khi bạn quay lại, ánh mắt ấy đã biến mất.

-> chapter1_ending


=== chapter1_ending ===

{
    - evidence >= 2:
        -> ending_detective
    - trustLinh >= 3:
        -> ending_friendship
    - else:
        -> ending_mystery
}

=== ending_detective ===

Người kể: <color=cyan><b>KẾT THÚC CHƯƠNG 1 — MANH MỐI ĐẦU TIÊN</b></color>

Người kể: Bạn đã phát hiện những chi tiết bất thường trong vụ rò rỉ tin nhắn.

Người kể: Kẻ đứng sau chuyện này có lẽ đã phạm phải một sai lầm.

Người kể: <i>Nhưng liệu bạn có tìm ra hắn trước khi quá muộn?</i>

-> END


=== ending_friendship ===

Người kể: <color=cyan><b>KẾT THÚC CHƯƠNG 1 — NIỀM TIN MONG MANH</b></color>

Người kể: Dù sự thật vẫn chưa rõ ràng, Linh bắt đầu tin tưởng bạn trở lại.

Người kể: Nhưng một lời xin lỗi liệu có đủ để hàn gắn mọi chuyện?

-> END


=== ending_mystery ===

Người kể: <color=red><b>KẾT THÚC CHƯƠNG 1 — BÓNG TỐI TRONG LỚP HỌC</b></color>

Người kể: Không ai biết kẻ đã phát tán những bức ảnh là ai.

Người kể: Và bạn có linh cảm rằng...

Người kể: <b>Đây mới chỉ là khởi đầu.</b>

-> END
