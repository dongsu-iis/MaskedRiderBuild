# README

## �T�v
�I�������t�H���_�z����VB��C#�̃v���W�F�N�g��ΏۂɎ����r���h���s���B  
�r���h�c�[����MsBuild��p����B


�@
## �@�\
1. �w�肳�ꂽ�t�H���_�z���i�T�u�t�H���_���܂ށj�̃v���W�F�N�g��ΏۂɁA�r���h���s��
2. ��ʂŎw�肳�ꂽ�u.NET Framework�̃o�[�W�����v�Ɓu�R���p�C�����郂�W���[���̃r�b�g���v��S�v���W�F�N�g�ɓK�p����
3. �v���W�F�N�g���m�̎Q�ƈˑ������m���A�r���h���Ԃ������I�ɕ��ёւ���
4. �r���h���ʂ���ʈꗗ�ɕ\�����A�r���h���O���o�͂���


�@
## �����ݒ�
�{�c�[���Ɠ�������ݒ�t�@�C���iRabbitTank.exe.config�j��appSettings�����[�U�[���ɍ��킹�ď��������Ă��������B  


��j  
```xml:App.config
<appSettings>
    <!-- �Q�ƈˑ��͌��m���Ȃ����߂̏��O����Q�ƃ��X�g -->
    <add key="json_system_list" value="[
         {'name':'System'},
         {'name':'CrystalDecisions'},
         {'name':'Microsoft'},
         {'name':'C1'},
         {'name':'FlashControlV71'},
         {'name':'office'},
         {'name':'Oracle'},
         {'name':'GrapeCity'},
         {'name':'Interop'},
         {'name':'Ionic.Zip'},
         ]
         "/>
    
    <!-- �Q�ƈˑ��͌��m���Ȃ����߂̏��O����Q�ƃ��X�g 
         ���̃��X�g�Ɋ܂܂�Ă��Ȃ��Q�Ƃ̃p�X�͏o�̓t�H���_�ɂȂ�-->
    <add key="json_system_list_partial" value="[
         {'name':'System'},
         {'name':'Microsoft.VisualBasic'},
         {'name':'office'},
         {'name':'CrystalDecisions'},
         {'name':'FlashControlV71'},
         {'name':'C1'},
         {'name':'GrapeCity'},
         ]
         "/>


    <!--�Q�Ƃ̒u���������X�g�idll�o�[�W�����A�b�v�̍ۂɗp����Ƃ����j-->
    <add key="json_convert_ref" value="[
         {'from':'Oracle.DataAccess','to':'Oracle.DataAccess'},
         ]
         "/>

    <!-- MSBuild�̃p�X�i���g��Visual Studio�t����MSBuild���w�肷��j -->
    <add key="MSBuildPath" value="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe"/>
</appSettings>
```


�@
## ���̑�
�܂��A�Ƃ肠�����g���Č��Ă��������B